using TDRData.Interface;
using TDRDomain.Interfaces;

namespace TDRDomain.Services.IServices
{
    public interface IBaseReadOnlyService<ReadModel, Model>
        where ReadModel : IBaseReadViewModel
        where Model : class, IBaseModel
    {
        Task<IEnumerable<ReadModel>> ListAsync(Func<Model, bool> predicate, params string[] includes);

        Task<ReadModel?> FindByAsync(Func<Model, bool> predicate, params string[] includes);
    }
}
