using AutoMapper;
using TDR.Models;
using TDR.ViewModels.Cardapios;

namespace TDRDomain.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<CreateMenuViewModel, Menu>();
            CreateMap<UpdateMenuViewModel, Menu>();
            CreateMap<Menu, ReadMenuViewModel>();
            CreateMap<ReadMenuViewModel, UpdateMenuViewModel>();
        }
    }
}
