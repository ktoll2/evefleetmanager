using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.SSO;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Models;
using EveFleetManager.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace EveFleetManager.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEsiClient _esiClient;
        private readonly List<string> _esiAuthScopes;
        private ICharacterService _charactorService;
        private ISessionService _sessionService;

        public AuthService(IEsiClient esiClient,
            IOptions<EsiAuthScopesModel> esiAuthScopes, 
            ICharacterService characterService,
            ISessionService sessionService)
        {
            _charactorService = characterService;
            _esiAuthScopes = esiAuthScopes.Value.Scopes;
            _esiClient = esiClient;
            _sessionService = sessionService;
        }

        public string Callback(string code)
        {
            SsoToken ssoToken = _esiClient.SSO.GetToken(GrantType.AuthorizationCode, code).Result;
            AuthorizedCharacterData auth_char = _esiClient.SSO.Verify(ssoToken).Result;

            Session session = _sessionService.CreateSession(auth_char.CharacterID);
            _charactorService.UpdateCharacterInformation(auth_char);

            return session.SessionId;
        }

        public SsoToken RefreshBearerToken(string refreshToken)
        {
            try
            {
                SsoToken token = _esiClient.SSO.GetToken(GrantType.RefreshToken, refreshToken).Result;

                return token;
            }
            catch(Exception ex)
            {
                throw new Exception("failed to refresh bearer token:" + refreshToken + ex.InnerException.ToString());
            }
          
        }

        public AuthorizedCharacterData GetAuthorizedCharacterData(string RefreshToken)
        {
            SsoToken ssoToken = RefreshBearerToken(RefreshToken);
            AuthorizedCharacterData auth_char = _esiClient.SSO.Verify(ssoToken).Result;

            _charactorService.UpdateCharacterInformation(auth_char);

            return auth_char;

        }



    }
}
