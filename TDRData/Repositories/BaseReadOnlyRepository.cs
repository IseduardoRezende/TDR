using Microsoft.EntityFrameworkCore;
using TDRData.Interface;
using TDRData.Repositories.IRepositories;

namespace TDRData.Repositories
{
    public abstract class BaseReadOnlyRepository<Model> : IBaseReadOnlyRepository<Model>
        where Model : class, IBaseModel
    {
        protected TDRContext Context { get; }

        protected DbSet<Model> Entity { get; }

        protected BaseReadOnlyRepository(TDRContext context)
        {
            Context = context;
            Entity = Context.Set<Model>();
        }

        public virtual async Task<IEnumerable<Model>> ListAsync(Func<Model, bool> predicate, params string[] includes)
        {
            IQueryable<Model> query = Entity;

            foreach (var include in includes)
                query = query.Include(include);

            return await Task.FromResult(query.Where(predicate).OrderByDescending(c => c.CreatedAt).ToList());
        }

        public virtual async Task<Model?> FindByAsync(Func<Model, bool> predicate, params string[] includes)
        {
            IQueryable<Model> query = Entity;

            foreach (var include in includes)
                query = query.Include(include);

            return await Task.FromResult(query.FirstOrDefault(predicate));
        }
    }
}
