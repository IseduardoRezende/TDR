﻿using AutoMapper;
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
            updateModel.Salt = Guid.NewGuid().ToString();
            updateModel.Password = updateModel.Password.ConvertToSHA512(updateModel.Salt);
            updateModel.Email = updateModel.Email.BuildEmail();

            return await base.UpdateAsync(updateModel);
        }

        public override async Task<ReadUserViewModel> CreateAsync(CreateUserViewModel createModel)
        {
            createModel.Salt = Guid.NewGuid().ToString();
            createModel.Password = createModel.Password.ConvertToSHA512(createModel.Salt);
            createModel.Email = createModel.Email.BuildEmail();

            return await base.CreateAsync(createModel);
        }

        public async Task<ReadUserViewModel> LogInAsync(ReadLoginViewModel login)
        {
            if (login == null) return null;

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

        public override async Task<ReadUserViewModel> IsValidCreate(CreateUserViewModel createModel)
        {
            var readModel = base.BuildReadModel();

            if (createModel == null)
                readModel.BaseError!.AddError(nameof(createModel), "Null object");

            if (createModel!.Password != createModel.ConfirmPassword)
                readModel.BaseError!.AddError(string.Concat($"{nameof(createModel.Password)}, {nameof(createModel.ConfirmPassword)}"), "Different Passwords");

            if (!createModel.Email.IsValidEmail())
                readModel.BaseError!.AddError(nameof(createModel.Email), "Invalid Email");

            var user = await base.FindByAsync(u => u.Email.Equals(createModel.Email, StringComparison.OrdinalIgnoreCase));

            if (user != null)
                readModel.BaseError!.AddError(nameof(createModel.Email), "Email already existing in the database");

            return readModel;
        }

        public override async Task<ReadUserViewModel> IsValidUpdate(UpdateUserViewModel updateModel)
        {
            var readModel = base.BuildReadModel();

            if (updateModel == null)
                readModel.BaseError!.AddError(nameof(updateModel), "Null object");

            if (updateModel!.Password != updateModel.ConfirmPassword)
                readModel.BaseError!.AddError(string.Concat($"{nameof(updateModel.Password)}, {nameof(updateModel.ConfirmPassword)}"), "Different Passwords");

            if (!updateModel.Email.IsValidEmail())
                readModel.BaseError!.AddError(nameof(updateModel.Email), "Invalid Email");

            var user = await base.FindByAsync(u => u.Email.Equals(updateModel.Email, StringComparison.OrdinalIgnoreCase));

            if (user != null && !user.Email.Equals(updateModel.Email, StringComparison.OrdinalIgnoreCase))
                readModel.BaseError!.AddError(nameof(updateModel.Email), "Email already existing in the database");

            return readModel;
        }

        public override User UpdateFields(User model, UpdateUserViewModel updateModel)
        {
            model.Email = updateModel.Email;
            model.Password = updateModel.Password;
            model.PeriodFk = updateModel.PeriodFk;

            return model;
        }
    }
}
