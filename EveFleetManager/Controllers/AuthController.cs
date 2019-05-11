using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.SSO;
using EveFleetManager.Controllers.Interfaces;
using EveFleetManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EveFleetManager.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller, IAuthController
    {
        private readonly List<string> _esiAuthScopes;
        private readonly IEsiClient _esiClient;

        public AuthController(IEsiClient esiClient, IOptions<EsiAuthScopesModel> esiAuthScopes)
        {
            _esiClient = esiClient;
            _esiAuthScopes = esiAuthScopes.Value.EsiAuthScopes;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            var authenticationUrl = _esiClient.SSO.CreateAuthenticationUrl(_esiAuthScopes);
            return Redirect(authenticationUrl);
        }

        [HttpGet("Callback")]
        public async Task<IActionResult> Callback(string code)
        {
            SsoToken ssoToken = await _esiClient.SSO.GetToken(GrantType.AuthorizationCode, code);
            AuthorizedCharacterData auth_char = await _esiClient.SSO.Verify(ssoToken);
            return Redirect("~/Home/Index");
        }
    }
}