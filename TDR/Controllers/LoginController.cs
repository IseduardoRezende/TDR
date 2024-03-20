using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDR.Extensions;
using TDR.ViewModels.Login;
using TDR.ViewModels.Logins;
using TDRConfiguration;
using TDRDomain.Services.IServices;

namespace TDR.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (!HttpContext.IsLogged())
                return View();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ReadLoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userService.LogInAsync(login);

            if (user == null)
                return View();

            await ConfigureClaims.ConfigureLogIn(HttpContext, user);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userService.CreateAsync(login);

            if (user.BaseError != null)
            {
                ViewData["BaseError"] = user.BaseError;
                return View();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ReactivateAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReactivateAccount(string email)
        {
            if (string.IsNullOrEmpty(email))
                return View();

            await _userService.ReactivateAccount(new ReadLoginViewModel { Email = email });
            return RedirectToAction("Index");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return View();

            await _userService.ResetPassword(new ReadLoginViewModel { Email = email });

            return RedirectToAction("Index");
        }
    }
}
