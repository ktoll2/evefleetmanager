using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EveFleetManager.Models;
using Microsoft.AspNetCore.Http;
using EveFleetManager.Services.Interfaces;

namespace EveFleetManager.Controllers
{
    public class HomeController : Controller
    {
        private ISessionService _sessionService;

        public HomeController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            string sessionIdCookie = "";

            if (!Request.Cookies.TryGetValue("EveFleetSession", out sessionIdCookie) && 
                string.IsNullOrWhiteSpace(sessionIdCookie) && 
                _sessionService.IsSessionValid(sessionIdCookie))
            {
                return RedirectToAction("auth", "login");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
