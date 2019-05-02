using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Services.Interfaces;

namespace EveFleetManager.Services
{
    public class CharacterService : ICharacterService
    {
        private EveFleetManagerContext _dbContext;

        public CharacterService(EveFleetManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Character GetCharacter(long characterId)
        {
            return _dbContext.Character.FirstOrDefault(x => x.Id == characterId);
        }
    }
}
