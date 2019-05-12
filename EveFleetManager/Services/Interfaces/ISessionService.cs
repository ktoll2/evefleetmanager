using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Services.Interfaces
{
    public interface ISessionService
    {
        Session GetSessionByCharacterId(int characterId);
        Session GetSessionBySessionId(string sessionId);
        Session CreateSession(int characterId);
        bool IsSessionValid(string sessionId);
    }
}
