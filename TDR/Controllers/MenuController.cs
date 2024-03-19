using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDR.Extensions;
using TDR.Models;
using TDR.ViewModels.Cardapios;
using TDRData.Models;
using TDRDomain.Services.IServices;

namespace TDR.Controllers
{
    public class MenuController : BaseController<CreateMenuViewModel, UpdateMenuViewModel, ReadMenuViewModel, Menu>
    {
        private readonly IMenuService _menuService;
        private readonly IVoteService _voteService;
        private readonly Settings _settings;

        public MenuController(IMenuService menuService, IVoteService voteService, Settings settings, IMapper mapper) : base(menuService, mapper)
        {
            _menuService = menuService;
            _voteService = voteService;
            _settings = settings;
        }
        
        [Authorize(Policy = "Admkitchen")]
        public override IActionResult Create()
        {
            var period = Convert.ToInt64(User.GetClaimValueByType("Period"));

            var menu = _menuService.GetCurrentMenuAsync(period).GetAwaiter().GetResult();

            //Permitido registrar apenas uma Refeição por dia
            if (menu != null)
                return RedirectToAction("Index");

            ViewData["Period"] = period;

            return base.Create();
        }

        [Authorize(Policy = "Admkitchen")]
        public override Task<IActionResult> Edit(long? id)
        {
            ViewData["Period"] = Convert.ToInt64(User.GetClaimValueByType("Period"));
            return base.Edit(id);
        }
        
        [Authorize(Policy = "Admkitchen")]
        public override Task<IActionResult> Delete(long? id)
        {
            return base.Delete(id);
        }

        public override async Task<IActionResult> Index()
        {
            ViewData["Email"] = User.GetClaimValueByType("Email");
            ViewData["Settings"] = _settings;

            var period = Convert.ToInt64(User.GetClaimValueByType("Period"));

            //Filtrando Menus por Período equivalente a do usuário conectado
            var menus = await _menuService.GetMenusAsync(period);
            return View(menus);
        }

        public override async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return BadRequest();

            ViewData["Email"] = User.GetClaimValueByType("Email");
            ViewData["Settings"] = _settings;

            var period = Convert.ToInt64(User.GetClaimValueByType("Period"));

            //Filtrando Menu por Período equivalente a do usuário conectado
            var menu = await _menuService.GetMenuByIdAsync(id.Value, period);

            if (menu == null)
                return NotFound();

            menu.QtyVotes = _voteService.GetTotalVotes((long)menu.Id!);

            return View(menu);
        }
    }
}
