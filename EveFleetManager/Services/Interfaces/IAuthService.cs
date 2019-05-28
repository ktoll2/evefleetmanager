using ESI.NET.Models.SSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Services.Interfaces
{
    public interface IAuthService
    {
        SsoToken RefreshBearerToken(string refreshToken);
        string Callback(string code);
        AuthorizedCharacterData GetAuthorizedCharacterData(string RefreshToken);
    }
}
