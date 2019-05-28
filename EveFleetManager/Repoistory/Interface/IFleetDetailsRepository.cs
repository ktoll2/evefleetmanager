using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Repoistory.Interface
{
    public interface IFleetDetailsRepository
    {
        void SaveFleetDetailsList(List<FleetDetail> fleetDetail);
    }
}
