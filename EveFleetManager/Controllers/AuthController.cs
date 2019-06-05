using System.Collections.Generic;
using ESI.NET;
using ESI.NET.Models.SSO;
using EveFleetManager.Controllers.Interfaces;
using EveFleetManager.Models;
using EveFleetManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EveFleetManager.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller, IAuthController
    {
        private readonly List<string> _esiAuthScopes;
        private readonly IEsiClient _esiClient;
        private ISessionService _sessionService;
        private ICharacterService _charactorService;
        private IAuthService _authService;

        public AuthController(IEsiClient esiClient,
            IOptions<EsiAuthScopesModel> esiAuthScopes,
            ISessionService sessionService,
            ICharacterService characterService,
            IAuthService authService
            )
        {
            _authService = authService;
            _sessionService = sessionService;
            _esiClient = esiClient;
            _esiAuthScopes = esiAuthScopes.Value.Scopes;
            _charactorService = characterService;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {

            var authenticationUrl = _esiClient.SSO.CreateAuthenticationUrl(_esiAuthScopes);
            return Redirect(authenticationUrl);
        }

        [HttpGet("Callback")]
        public IActionResult Callback(string code)
        {


            var session = _authService.Callback(code);

            Response.Cookies.Append("EveFleetSession", session);

            return Redirect("~/Home/Index");
        }

        [HttpGet("Refresh")]
        public IActionResult Refresh(string refreshToken)
        {

            SsoToken token = _authService.RefreshBearerToken(refreshToken);

            return Ok(token);
        }
    }
}