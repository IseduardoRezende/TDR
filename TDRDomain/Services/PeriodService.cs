using AutoMapper;
using TDRData.Models;
using TDRData.Repositories.IRepositories;
using TDRDomain.Services.IServices;
using TDRDomain.ViewModels.Period;

namespace TDRDomain.Services
{
    public class PeriodService : BaseReadOnlyService<ReadPeriodViewModel, Period>, IPeriodService
    {
        public PeriodService(IPeriodRepository periodRepository, IMapper mapper) : base(periodRepository, mapper)
        {
        }
    }
}
