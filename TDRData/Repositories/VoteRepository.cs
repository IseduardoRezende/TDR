using TDR.Models;
using TDRData.Repositories.IRepositories;

namespace TDRData.Repositories
{
    public class VoteRepository : BaseRepository<Vote>, IVoteRepository
    {
        public VoteRepository(TDRContext context) : base(context) { }
    }
}
