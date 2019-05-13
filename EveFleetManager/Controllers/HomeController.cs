using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EveFleetManager.Models;
using Microsoft.AspNetCore.Http;
using EveFleetManager.Services.Interfaces;

using EveFleetManager.DataContext.Models;
using System.Threading.Tasks;

namespace EveFleetManager.Controllers
{
    public class HomeController : Controller
    {
        private ISessionService _sessionService;
        private ICharacterService _characterService;
        private IFleetService _fleetService;
        public HomeController(ISessionService sessionService,ICharacterService characterservice,IFleetService fleetService)
        {
            _fleetService = fleetService;
            _sessionService = sessionService;
            _characterService = characterservice;
        }

        public IActionResult Index()
        {
            string sessionIdCookie = "";

            if (!Request.Cookies.TryGetValue("EveFleetSession", out sessionIdCookie) && 
                string.IsNullOrWhiteSpace(sessionIdCookie) && 
                !_sessionService.IsSessionValid(sessionIdCookie))
            {
                return RedirectToAction("login","auth");
            }
            Session session = _sessionService.GetSessionBySessionId(sessionIdCookie);
            Character character = _characterService.GetCharacter(session.CharacterId);

            var potato = _fleetService.CharacterHasActiveFleet(character.Id);

            FleetWithInfo ActiveFleet =  _fleetService.StartFleet(character);

            return View();
        }


        public IActionResult StartFleet()
        {



            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
