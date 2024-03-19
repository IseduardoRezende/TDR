using TDR.Models;
using TDR.ViewModels.Votacao;

namespace TDRDomain.Services.IServices
{
    public interface IVoteService : IBaseService<CreateVoteViewModel, UpdateVoteViewModel, ReadVoteViewModel, Vote>
    {
        Task<ReadVoteViewModel?> GetCurrentVoteAsync(long userFk, long periodFk);

        Task<ReadVoteViewModel?> GetCurrentVoteByIdAsync(long id, long userFk, long periodFk);

        bool CanVote(ReadVoteViewModel vote);

        ushort GetTotalVotes(long menuId);
    }
}
