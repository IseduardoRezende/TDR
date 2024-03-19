using TDR.Models;
using TDR.ViewModels.Login;
using TDR.ViewModels.Usuario;

namespace TDRDomain.Services.IServices
{
    public interface IUserService : IBaseService<CreateUserViewModel, UpdateUserViewModel, ReadUserViewModel, User>
    {
        Task<ReadUserViewModel> LogInAsync(ReadLoginViewModel login);

        Task ReactivateAccount(ReadLoginViewModel user);

        Task ResetPassword(ReadLoginViewModel user);
    }
}
