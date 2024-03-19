using TDRData.Interface;

namespace TDRData.Repositories.IRepositories
{
    public interface IBaseRepository<Model> : IBaseReadOnlyRepository<Model>
        where Model : class, IBaseModel
    {
        Task<Model> CreateAsync(Model model);

        Task<Model> UpdateAsync(Model model);

        Task DeleteAsync(Model model);
    }
}
