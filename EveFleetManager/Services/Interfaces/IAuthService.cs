using ESI.NET.Models.SSO;

namespace EveFleetManager.Services.Interfaces
{
    public interface IAuthService
    {
        SsoToken RefreshBearerToken(string refreshToken);
        string Callback(string code);
        AuthorizedCharacterData GetAuthorizedCharacterData(string RefreshToken);
    }
}
