using TDRData.Interface;
using TDRDomain.Interfaces;

namespace TDRDomain.Services.IServices
{
    public interface IBaseService<CreateModel, UpdateModel, ReadModel, Model> : IBaseReadOnlyService<ReadModel, Model>
        where CreateModel : IBaseCreateViewModel
        where UpdateModel : IBaseUpdateViewModel
        where ReadModel : IBaseReadViewModel
        where Model : class, IBaseModel
    {
        Task<ReadModel> CreateAsync(CreateModel createModel);

        Task<ReadModel> UpdateAsync(UpdateModel updateModel);

        Task DeleteAsync(long id);
    }
}