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
        where ReadModel : IBaseReadViewModel
        where Model : class, IBaseModel
    {
        protected IBaseRepository<Model> BaseRepository { get; }

        protected BaseService(IBaseRepository<Model> baseRepository, IMapper mapper) : base(baseRepository, mapper)
        {
            BaseRepository = baseRepository;
        }

        public virtual async Task<ReadModel> CreateAsync(CreateModel createModel)
        {           
            var model = Mapper.Map<Model>(createModel);

            var createdModel = await BaseRepository.CreateAsync(model);
        
            return Mapper.Map<ReadModel>(createdModel);
        }

        public virtual async Task<ReadModel> UpdateAsync(UpdateModel updateModel)
        {           
            var model = Mapper.Map<Model>(updateModel);

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
    }
}
