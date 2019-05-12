using EveFleetManager.DataContext.Models;
using EveFleetManager.DataContext;
using EveFleetManager.Repositories.Interfaces;
using System.Linq;

namespace EveFleetManager.Respoitories
{
    public class CharacterRepository : ICharacterRepository
    {
        private EveFleetManagerContext _dbContext;

        public CharacterRepository(EveFleetManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Character CreateCharacter(Character character)
        {
            _dbContext.Character.Add(character);
            _dbContext.SaveChanges();
            return character;
        }

        public Character UpdateCharacter(Character character)
        {
            var oldCharacter = _dbContext.Character.FirstOrDefault(x => x.Id == character.Id);

            oldCharacter.Name = character.Name;
            oldCharacter.BearerToken = character.BearerToken;
            oldCharacter.RefreshToken = character.RefreshToken;
            oldCharacter.TokenExpires = character.TokenExpires;

            _dbContext.Character.Update(oldCharacter);
            _dbContext.SaveChanges();
            return oldCharacter;
        }

        public Character GetCharacterById(long characterId)
        {
            return _dbContext.Character.FirstOrDefault(x => x.Id == characterId);
        }
    }
}