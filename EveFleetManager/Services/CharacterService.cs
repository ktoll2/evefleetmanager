using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
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
