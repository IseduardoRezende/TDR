using TDRData.Interface;

namespace TDRData.Repositories.IRepositories
{
    public interface IBaseReadOnlyRepository<Model>
        where Model : class, IBaseModel
    {
        Task<IEnumerable<Model>> ListAsync(Func<Model, bool> predicate, params string[] includes);

        Task<Model?> FindByAsync(Func<Model, bool> predicate, params string[] includes);
    }
}
