using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Repositories.Interfaces;
using System.Collections.Generic;

namespace EveFleetManager.Repositories
{
    public class FleetDetailsRepository : IFleetDetailsRepository
    {

        private EveFleetManagerContext _dbContext;

        public FleetDetailsRepository(EveFleetManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveFleetDetailsList(List<FleetDetail> fleetDetailList)
        {
            _dbContext.FleetDetail.AddRange(fleetDetailList);
            _dbContext.SaveChanges();
        }
    }
}
