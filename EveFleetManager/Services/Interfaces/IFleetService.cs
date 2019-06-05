using EveFleetManager.DataContext.Models;
using EveFleetManager.Models;

namespace EveFleetManager.Services.Interfaces
{
    public interface IFleetService
    {
        bool CharacterHasActiveFleet(long CharacterId);

        FleetWithInfo StartFleet(Session SessionId);

        FleetWithInfo GetActiveFleet(Character character);
    }
}
