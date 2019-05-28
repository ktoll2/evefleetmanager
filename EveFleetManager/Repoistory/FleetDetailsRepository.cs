using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Repoistory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Repoistory
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
