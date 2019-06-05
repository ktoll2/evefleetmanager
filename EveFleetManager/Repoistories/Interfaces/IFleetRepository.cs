using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Repositories.Interfaces
{
    public interface IFleetRepository
    {
        bool CharacterHasActiveFleet(long characterid);
        Fleet CreateNewFleet(long characterId);
        void EndActiveFleet(long characterId);
        Fleet GetCharactersActiveFleet(long characterId);
    }
}
