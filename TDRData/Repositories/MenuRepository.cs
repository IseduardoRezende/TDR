using TDR.Models;
using TDRData.Repositories.IRepositories;

namespace TDRData.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(TDRContext context) : base(context) { }
    }
}
