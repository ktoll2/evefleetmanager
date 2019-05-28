using EveFleetManager.DataContext.Models;
using EveFleetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Services.Interfaces
{
   public interface IFleetService
    {
        bool CharacterHasActiveFleet(long CharacterId);

        FleetWithInfo StartFleet(Session SessionId);

        FleetWithInfo GetActiveFleet(Character character);
    }
}
