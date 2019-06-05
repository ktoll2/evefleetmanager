using System.Collections.Generic;
using ESI.NET.Models.Fleets;
using ESI.NET.Models.SSO;
using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Services.Interfaces
{
    public interface ICharacterService
    {
        Character GetCharacter(long characterId);

        void UpdateCharacterInformation(AuthorizedCharacterData characterData);
        List<Character> AddCharactorsToDatabaseIfNotAlready(List<Member> fleetData);
    }
}
