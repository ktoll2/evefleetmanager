using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Session CreateSession(Session session);
        Session GetSessionByCharacterId(int characterId);
        Session GetSessionBySessionId(string sessionId);
        void RemoveSessionsByCharacterId(long characterId);
    }
}