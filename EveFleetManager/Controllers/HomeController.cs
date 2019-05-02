using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using Microsoft.AspNetCore.Mvc;
using EveFleetManager.Models;
using RestSharp;

namespace EveFleetManager.Controllers
{
    public class HomeController : Controller
    {
        string clientSecert = "V7oO1whlolByDIYcl6QtEpyFvONJC1idmOaAyujt";
        string clientId = "49cfd7219dcf49eeb1d8dad0b051088f";
        string callBackUrl = "https://localhost:44390/home/Callback";

        string eveTokenPostUrl = "https://login.eveonline.com/v2/oauth/token";

        public IActionResult Index()
        {
            IRestClient httpClient = new RestClient();
            httpClient.BaseUrl = new Uri("https://login.eveonline.com/v2/oauth/authorize/");

            var httpRequest = new RestRequest();
            httpRequest.Method = Method.GET;

            httpRequest.AddQueryParameter("response_type", "code");
            httpRequest.AddQueryParameter("redirect_uri", callBackUrl);
            httpRequest.AddQueryParameter("client_id", clientId);
            httpRequest.AddQueryParameter("scope", "esi-fleets.read_fleet.v1");
            httpRequest.AddQueryParameter("state", "potato");

            var result = httpClient.Get(httpRequest);
            return Redirect(result.ResponseUri.ToString());


        }

        public IActionResult Callback([FromQuery] string code,[FromQuery] string state)
        {
            IRestClient httpClient = new RestClient();
            httpClient.BaseUrl = new Uri(eveTokenPostUrl);

            var httpRequest = new RestRequest();
            httpRequest.Method = Method.POST;
           
            var credBytes = System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecert}");
            var creds = Convert.ToBase64String(credBytes);

            httpRequest.AddHeader("Authorization", $"Basic {creds}");
            httpRequest.AddHeader("Accept", "application/json");
            httpRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            httpRequest.AddHeader("Host", "login.eveonline.com");
            httpRequest.AddParameter("grant_type", "authorization_code");
            httpRequest.AddParameter("code", code);

            var result = httpClient.Post(httpRequest);
            return View("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
