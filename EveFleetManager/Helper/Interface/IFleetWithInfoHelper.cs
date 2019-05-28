using EveFleetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Helper.Interface
{
    public interface IFleetWithInfoHelper
    {
        FleetWithInfo CreateNewFleet(List<int> charId);
    }
}
