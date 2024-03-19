using TDRData.Models;
using TDRData.Repositories.IRepositories;

namespace TDRData.Repositories
{
    public class PeriodRepository : BaseReadOnlyRepository<Period>, IPeriodRepository
    {
        public PeriodRepository(TDRContext context) : base(context) { }
    }
}
