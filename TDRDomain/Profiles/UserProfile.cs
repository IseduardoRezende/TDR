using AutoMapper;
using TDR.Models;
using TDR.ViewModels.Usuario;

namespace TDRDomain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserViewModel, User>();
            CreateMap<UpdateUserViewModel, User>();
            CreateMap<User, ReadUserViewModel>();
            CreateMap<ReadUserViewModel, UpdateUserViewModel>();
        }
    }
}
