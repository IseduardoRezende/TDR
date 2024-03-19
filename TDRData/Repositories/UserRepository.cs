using TDR.Models;
using TDRData.Repositories.IRepositories;

namespace TDRData.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TDRContext context) : base(context) { }
    }
}
