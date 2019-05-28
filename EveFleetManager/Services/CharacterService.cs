using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESI.NET;
using ESI.NET.Models.Fleets;
using ESI.NET.Models.SSO;
using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Repositories.Interfaces;
using EveFleetManager.Services.Interfaces;

namespace EveFleetManager.Services
{
    public class CharacterService : ICharacterService
    {
        private ICharacterRepository _characterRepository;
        private IEsiClient _esiclient;

        public CharacterService(ICharacterRepository characterRepository, IEsiClient esiClient)
        {
            _esiclient = esiClient;
            _characterRepository = characterRepository;
        }

        public List<Character> AddCharactorsToDatabaseIfNotAlready(List<Member> fleetData)
        {
            List<Character> results = new List<Character>();

            foreach (var x in fleetData)
            {
                var character = GetCharacter(x.CharacterId);

                if (character == null)
                {
                   var charResults= _esiclient.Character.Information(x.CharacterId).Result.Data;
                    Character newCharacter = new Character()
                    {

                        Id = x.CharacterId,
                        Name = charResults.Name,
                        BearerToken = "Null",
                        RefreshToken = "Null",
                        TokenExpires = DateTime.Now

                    };

                    _characterRepository.CreateCharacter(character);
                    results.Add(newCharacter);

                }
                else
                {
                    results.Add(character);
                }
            }

            return results;
        }

        public Character GetCharacter(long characterId)
        {
            return _characterRepository.GetCharacterById(characterId);
        }

        public void UpdateCharacterInformation(AuthorizedCharacterData characterData)
        {
            
            var character = GetCharacter(characterData.CharacterID);

            if (character == null )
            {
                character = new Character()
                {
                    BearerToken = characterData.Token,
                    Id = characterData.CharacterID,
                    Name = characterData.CharacterName,
                    RefreshToken = characterData.RefreshToken,
                    TokenExpires = characterData.ExpiresOn
                };

                _characterRepository.CreateCharacter(character);

            }
            else
            {
                character.BearerToken = characterData.Token;
                character.Id = characterData.CharacterID;
                character.Name = characterData.CharacterName;
                character.RefreshToken = characterData.RefreshToken;
                character.TokenExpires = characterData.ExpiresOn;
                _characterRepository.UpdateCharacter(character);
            }


            
           
        }
    }
}
