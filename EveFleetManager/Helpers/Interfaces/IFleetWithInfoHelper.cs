using EveFleetManager.Models;
using System.Collections.Generic;

namespace EveFleetManager.Helpers.Interfaces
{
    public interface IFleetWithInfoHelper
    {
        FleetWithInfo CreateNewFleet(List<int> charId);
    }
}
