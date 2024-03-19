using TDRData.Interface;
using TDRData.Repositories.IRepositories;

namespace TDRData.Repositories
{
    public abstract class BaseRepository<Model> : BaseReadOnlyRepository<Model>, IBaseRepository<Model>
        where Model : class, IBaseModel
    {
        protected BaseRepository(TDRContext context) : base(context) { }

        public virtual async Task<Model> CreateAsync(Model model)
        {
            var createdModel = Entity.Add(model);
            await SaveChangesAsync();
            return await base.FindByAsync(a => a.Id == createdModel.Entity.Id);
        }
        
        public virtual async Task<Model> UpdateAsync(Model model)
        {
            var updatedModel = Entity.Update(model);
            await SaveChangesAsync();
            return await base.FindByAsync(a => a.Id == updatedModel.Entity.Id);
        }
        
        public virtual async Task DeleteAsync(Model model)
        {
            model.DeletedAt = DateTime.Now;
            Entity.Update(model);
            await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
