using AutoMapper;
using TDRData.Models;
using TDRDomain.ViewModels.Period;

namespace TDRDomain.Profiles
{
    public class PeriodProfile : Profile
    {
        public PeriodProfile()
        {
            CreateMap<Period, ReadPeriodViewModel>();
        }
    }
}
