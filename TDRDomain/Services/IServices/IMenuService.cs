using TDR.Models;
using TDR.ViewModels.Cardapios;

namespace TDRDomain.Services.IServices
{
    public interface IMenuService : IBaseService<CreateMenuViewModel, UpdateMenuViewModel, ReadMenuViewModel, Menu>
    {
        Task<IEnumerable<ReadMenuViewModel>> GetMenusAsync(long periodFk);

        Task<ReadMenuViewModel?> GetMenuByIdAsync(long id, long periodFk);

        Task<ReadMenuViewModel?> GetCurrentMenuAsync(long periodFk);
    }
}
