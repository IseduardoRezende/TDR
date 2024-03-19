using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TDR.Extensions;
using TDRConfiguration;
using TDRData.Models;

namespace TDR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly Settings _settings;

        public HomeController(Settings settings)
        {
            _settings = settings;
        }

        public IActionResult Index()
        {            
            ViewData["Email"] = User.GetClaimValueByType("Email");
            ViewData["Id"] = User.GetClaimValueByType("Id");
            return View(_settings);
        }

        public IActionResult Privacy()
        {
            return View();
        }        

        public async Task<IActionResult> LogOut()
        {
            await ConfigureClaims.ConfigureLogOut(HttpContext);
            return RedirectToAction("Index", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorView { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}