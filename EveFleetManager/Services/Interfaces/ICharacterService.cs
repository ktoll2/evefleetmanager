using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Services.Interfaces
{
    public interface ICharacterService
    {
        Character GetCharacter(long characterId);
    }
}
