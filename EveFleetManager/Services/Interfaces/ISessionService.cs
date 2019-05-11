using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Services.Interfaces
{
    public interface ISessionService
    {
        Session GetSessionByCharacterId(int characterId);
        Session CreateSession(int characterId);
    }
}
