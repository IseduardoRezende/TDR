using TDRData.Models;
using TDRDomain.ViewModels.Period;

namespace TDRDomain.Services.IServices
{
    public interface IPeriodService : IBaseReadOnlyService<ReadPeriodViewModel, Period>
    {
    }
}
