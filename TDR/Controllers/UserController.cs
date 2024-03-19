using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDR.Extensions;
using TDR.Models;
using TDR.ViewModels.Usuario;
using TDRConfiguration;
using TDRDomain.Services.IServices;

namespace TDR.Controllers
{
    public class UserController : BaseController<CreateUserViewModel, UpdateUserViewModel, ReadUserViewModel, User>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
            _userService = userService;
        }

        [Authorize(Policy = "Adm")]
        public override async Task<IActionResult> Index()
        {
            var users = await _userService.ListAsync(c => c.DeletedAt == null, "Period");
            return View(users);
        }

        public override async Task<IActionResult> Details(long? id)
        {
            if (!id.IsValidIdQueryParam(User))
                return Forbid();

            var user = await _userService.FindByAsync(c => c.Id == id && c.DeletedAt == null, "Period");
            return View(user);
        }

        public override async Task<IActionResult> Edit(long? id)
        {
            if (!id.IsValidIdQueryParam(User))
                return Forbid();

            return await base.Edit(id);
        }

        public override async Task<IActionResult> Edit(long id, UpdateUserViewModel updateModel)
        {
            if (id != updateModel.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(updateModel);

            await BaseService.UpdateAsync(updateModel);

            await ConfigureClaims.ConfigureLogOut(HttpContext);

            return RedirectToAction("Index", "Login");
        }

        public override async Task<IActionResult> Delete(long? id)
        {
            if (!id.IsValidIdQueryParam(User))
                return Forbid();

            var user = await _userService.FindByAsync(c => c.Id == id && c.DeletedAt == null, "Period");
            return View(user);
        }       
    }
}
