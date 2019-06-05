using System.Collections.Generic;
using EveFleetManager.DataContext.Models;

namespace EveFleetManager.Repositories.Interfaces
{
    public interface IFleetDetailsRepository
    {
        void SaveFleetDetailsList(List<FleetDetail> fleetDetail);
    }
}
