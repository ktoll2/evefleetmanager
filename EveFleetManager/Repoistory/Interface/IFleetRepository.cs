using EveFleetManager.DataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Repoistory.Interface
{
    public interface IFleetRepository
    {
        bool CharacterHasActiveFleet(long characterid);
        Fleet CreateNewFleet(long characterId);
        void EndActiveFleet(long characterId);
        Fleet GetCharactersActiveFleet(long characterId);
    }
}
