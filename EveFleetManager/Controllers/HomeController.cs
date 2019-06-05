using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EveFleetManager.Models;
using Microsoft.AspNetCore.Http;
using EveFleetManager.Services.Interfaces;
using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Controllers
{
    public class HomeController : Controller
    {
        private ISessionService _sessionService;
        private IFleetService _fleetService;
        public HomeController(IFleetService fleetService,ISessionService sessionService)
        {
            _fleetService = fleetService;
            _sessionService = sessionService;

        }

        public IActionResult Index()
        {
            string sessionIdCookie = GetSessionOutOfCookie();

            if (string.IsNullOrWhiteSpace(sessionIdCookie) 
                && !_sessionService.IsSessionValid(sessionIdCookie))
            {
                return RedirectToAction("login","auth");
            }

            return View();
        }


        public IActionResult StartFleet()
        {

            string sessionIdCookie = GetSessionOutOfCookie();

            Session session = _sessionService.GetSessionBySessionId(sessionIdCookie);

            FleetWithInfo ActiveFleet = _fleetService.StartFleet(session);



            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetSessionOutOfCookie()
        {
            string sessionIdCookie = "";
            Request.Cookies.TryGetValue("EveFleetSession", out sessionIdCookie);
            return sessionIdCookie;

        }
        
    }
}
