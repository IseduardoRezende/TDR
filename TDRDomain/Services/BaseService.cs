using AutoMapper;
using TDRData.Interface;
using TDRData.Repositories.IRepositories;
using TDRDomain.Interfaces;
using TDRDomain.Services.IServices;

namespace TDRDomain.Services
{
    public abstract class BaseService<CreateModel, UpdateModel, ReadModel, Model> : BaseReadOnlyService<ReadModel, Model>, IBaseService<CreateModel, UpdateModel, ReadModel, Model>
        where CreateModel : IBaseCreateViewModel
        where UpdateModel : IBaseUpdateViewModel
        where ReadModel : IBaseReadViewModel, new()
        where Model : class, IBaseModel
    {
        protected IBaseRepository<Model> BaseRepository { get; }

        protected BaseService(IBaseRepository<Model> baseRepository, IMapper mapper) : base(baseRepository, mapper)
        {
            BaseRepository = baseRepository;
        }

        public abstract Task<ReadModel> IsValidCreate(CreateModel createModel);

        public virtual async Task<ReadModel> CreateAsync(CreateModel createModel)
        {
            var validation = await IsValidCreate(createModel);

            if (validation.BaseError is { HasErrors: true, Errors.Count: > 0 })
                return validation;

            var model = Mapper.Map<Model>(createModel);

            var createdModel = await BaseRepository.CreateAsync(model);

            return Mapper.Map<ReadModel>(createdModel);
        }

        public abstract Task<ReadModel> IsValidUpdate(UpdateModel updateModel);
        
        public abstract Model UpdateFields(Model model, UpdateModel updateModel);

        public virtual async Task<ReadModel> UpdateAsync(UpdateModel updateModel)
        {
            var validation = await IsValidUpdate(updateModel);

            if (validation.BaseError is { HasErrors: true, Errors.Count: > 0 })
                return validation;

            var model = await BaseReadOnlyRepository.FindByAsync(m => m.Id == updateModel.Id);

            if (model == null)
            {
                validation.BaseError!.AddError(nameof(updateModel.Id), "Non-existent value");
                return validation; 
            }

            model = UpdateFields(model, updateModel);

            var updatedModel = await BaseRepository.UpdateAsync(model);

            return Mapper.Map<ReadModel>(updatedModel);
        }

        public virtual async Task DeleteAsync(long id)
        {
            var model = await BaseReadOnlyRepository.FindByAsync(a => a.Id == id);

            if (model == null)
                return;

            await BaseRepository.DeleteAsync(model);
        }

        protected ReadModel BuildReadModel()
        {
            var readModel = new ReadModel
            {
                BaseError = new Bases.BaseError()
            };

            return readModel;
        }
    }
}
