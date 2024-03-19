using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDRData.Interface;
using TDRDomain.Interfaces;
using TDRDomain.Services.IServices;

namespace TDR.Controllers
{
    [Authorize]
    public abstract class BaseReadOnlyController<ReadModel, Model> : Controller
        where ReadModel : IBaseReadViewModel
        where Model : class, IBaseModel
    {
        protected IMapper Mapper { get; }

        public IBaseReadOnlyService<ReadModel, Model> BaseReadOnlyService { get; }

        protected BaseReadOnlyController(IBaseReadOnlyService<ReadModel, Model> baseReadOnlyService, IMapper mapper)
        {
            BaseReadOnlyService = baseReadOnlyService;
            Mapper = mapper;
        }

        public virtual async Task<IActionResult> Index()
        {
            return View(await BaseReadOnlyService.ListAsync(c => c.DeletedAt == null));
        }     

        public virtual async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return BadRequest();           

            var readModel = await BaseReadOnlyService.FindByAsync(c => c.Id == id.Value && c.DeletedAt == null);

            if (readModel == null)
                return NotFound();

            return View(readModel);
        }        
    }
}
