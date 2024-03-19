using AutoMapper;
using TDRData.Interface;
using TDRData.Repositories.IRepositories;
using TDRDomain.Interfaces;
using TDRDomain.Services.IServices;

namespace TDRDomain.Services
{
    public abstract class BaseReadOnlyService<ReadModel, Model> : IBaseReadOnlyService<ReadModel, Model>
        where ReadModel : IBaseReadViewModel
        where Model : class, IBaseModel
    {
        protected IBaseReadOnlyRepository<Model> BaseReadOnlyRepository { get; }

        protected IMapper Mapper { get; }

        protected BaseReadOnlyService(IBaseReadOnlyRepository<Model> baseReadOnlyRepository, IMapper mapper)
        {
            BaseReadOnlyRepository = baseReadOnlyRepository;
            Mapper = mapper;
        }
        
        public virtual async Task<IEnumerable<ReadModel>> ListAsync(Func<Model, bool> predicate, params string[] includes)
        {
            var items = await BaseReadOnlyRepository.ListAsync(predicate, includes);
            return Mapper.Map<IEnumerable<ReadModel>>(items);
        }
        
        public virtual async Task<ReadModel?> FindByAsync(Func<Model, bool> predicate, params string[] includes)
        {
            var item = await BaseReadOnlyRepository.FindByAsync(predicate, includes);

            if (item == null)
                return default;

            return Mapper.Map<ReadModel>(item);
        }
    }
}
