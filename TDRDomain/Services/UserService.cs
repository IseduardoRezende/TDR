using AutoMapper;
using TDR.Models;
using TDR.ViewModels.Login;
using TDR.ViewModels.Usuario;
using TDRData.Models;
using TDRData.Repositories.IRepositories;
using TDRDomain.Extensions;
using TDRDomain.Services.IServices;

namespace TDRDomain.Services
{
    public class UserService : BaseService<CreateUserViewModel, UpdateUserViewModel, ReadUserViewModel, User>, IUserService
    {
        private readonly Settings _settings;

        public UserService(IUserRepository userRepository, Settings settings, IMapper mapper) : base(userRepository, mapper)
        {
            _settings = settings;  
        }        
        
        public override async Task<ReadUserViewModel> UpdateAsync(UpdateUserViewModel updateModel)
        {
            if (!await IsValidUpdateUser(updateModel)) return null;

            updateModel.Salt = Guid.NewGuid().ToString();
            updateModel.Password = updateModel.Password.ConvertToSHA512(updateModel.Salt);
            updateModel.Email = updateModel.Email.BuildEmail();

            return await base.UpdateAsync(updateModel);
        }

        private async Task<bool> IsValidUpdateUser(UpdateUserViewModel updateUser)
        {
            if (updateUser == null) return false;   

            if (updateUser.Password != updateUser.ConfirmPassword)
                return false;

            if (!updateUser.Email.IsValidEmail()) return false;
            
            var user = await base.FindByAsync(u => u.Email.Equals(updateUser.Email, StringComparison.OrdinalIgnoreCase));

            if (user != null && !user.Email.Equals(updateUser.Email, StringComparison.OrdinalIgnoreCase)) 
                return false;

            return true;
        }

        public override async Task<ReadUserViewModel> CreateAsync(CreateUserViewModel createModel)
        {
            if (!await IsValidCreateUser(createModel)) return null;

            createModel.Salt = Guid.NewGuid().ToString();
            createModel.Password = createModel.Password.ConvertToSHA512(createModel.Salt);
            createModel.Email = createModel.Email.BuildEmail();

            return await base.CreateAsync(createModel);
        }
        
        private async Task<bool> IsValidCreateUser(CreateUserViewModel createUser)
        {
            if (createUser == null) return false;

            if (createUser.Password != createUser.ConfirmPassword)
                return false;

            if (!createUser.Email.IsValidEmail()) return false;
            
            var user = await base.FindByAsync(u => u.Email.Equals(createUser.Email, StringComparison.OrdinalIgnoreCase));

            if (user != null) return false;

            return true;
        }

        public async Task<ReadUserViewModel> LogInAsync(ReadLoginViewModel login)
        {
            if (login == null)  return null;

            if (login.Email.IsDefaultUser(_settings) && !login.Email.IsValidEmail()) 
                return null;

            var user = await base.FindByAsync(u => u.Email.Equals(login.Email, StringComparison.OrdinalIgnoreCase), "Period");

            if (user == null || user.DeletedAt != null) return null;

            if (!IsValidPasword(login, user)) return null;

            return user;
        }

        private bool IsValidPasword(ReadLoginViewModel login, ReadUserViewModel user)
        {
            if (user == null || login == null) return false;

            var hashedPassword = login.Password.ConvertToSHA512(user.Salt);

            return hashedPassword.Equals(user.Password);
        }

        public async Task ReactivateAccount(ReadLoginViewModel user)
        {
            if (user == null || !user.Email.IsValidEmail()) return;

            var readUser = await base.FindByAsync(c => c.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase));

            if (readUser == null || readUser.DeletedAt == null) return;

            readUser.DeletedAt = null;

            await this.UpdateAsync(Mapper.Map<UpdateUserViewModel>(readUser));
        }
            
        public async Task ResetPassword(ReadLoginViewModel user)
        {
            if (user == null || !user.Email.IsValidEmail()) return;

            var readUser = await base.FindByAsync(c => c.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase));

            if (readUser == null) return;

            readUser.Salt = Guid.NewGuid().ToString();

            //var password = Random.Shared.Next(100000, 999999).ToString();

            var hashPassword = /*password*/111111.ToString().ConvertToSHA512(readUser.Salt);           

            readUser.Password = hashPassword;

            var updatedUser = await base.UpdateAsync(Mapper.Map<UpdateUserViewModel>(readUser));

            if (updatedUser == null) return;
            
            //TODO: SendEmail with the new password;
        } 
    }
}
