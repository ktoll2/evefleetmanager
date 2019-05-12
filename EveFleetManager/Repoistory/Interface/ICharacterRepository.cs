using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        Character GetCharacterById(long characterId);

        Character CreateCharacter(Character character);
        Character UpdateCharacter(Character character);
    }
}
