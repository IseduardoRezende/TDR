using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TDRData.Interface;
using TDRDomain.Interfaces;
using TDRDomain.Services.IServices;

namespace TDR.Controllers
{
    public abstract class BaseController<CreateModel, UpdateModel, ReadModel, Model> : BaseReadOnlyController<ReadModel, Model>
        where CreateModel : IBaseCreateViewModel
        where UpdateModel : IBaseUpdateViewModel
        where ReadModel : IBaseReadViewModel
        where Model : class, IBaseModel
    {
        public IBaseService<CreateModel, UpdateModel, ReadModel, Model> BaseService { get; }

        public BaseController(IBaseService<CreateModel, UpdateModel, ReadModel, Model> baseService, IMapper mapper) : base(baseService, mapper)
        {
            BaseService = baseService;
        }                       

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(CreateModel createModel)
        {
            if (!ModelState.IsValid)
                return View(createModel);
         
            await BaseService.CreateAsync(createModel);

            return RedirectToAction("Index", "Home");
        }       

        public virtual async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return BadRequest();          

            var readModel = await base.BaseReadOnlyService.FindByAsync(c => c.Id == id.Value && c.DeletedAt == null);

            if (readModel == null)
                return NotFound();

            var updateModel = Mapper.Map<UpdateModel>(readModel);

            return View(updateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(long id, UpdateModel updateModel)
        {
            if (id != updateModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(updateModel);

            await BaseService.UpdateAsync(updateModel);
            
            return RedirectToAction("Index", "Home");
        }        
        
        public virtual async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
                return BadRequest();

            var readModel = await base.BaseReadOnlyService.FindByAsync(c => c.Id == id.Value && c.DeletedAt == null);

            if (readModel == null)
                return NotFound();

            return View(readModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(long id)
        {           
            await BaseService.DeleteAsync(id);
            return RedirectToAction("Index", "Home");
        }        
    }
}
