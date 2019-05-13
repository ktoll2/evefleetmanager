using EveFleetManager.DataContext;
using EveFleetManager.Models;
using EveFleetManager.Repoistory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Repoistory
{
    public class FleetRepository : IFleetRepository
    {

        private EveFleetManagerContext _dbContext;
        public FleetRepository(EveFleetManagerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CharacterHasActiveFleet(long characterid)
        {
            int activeenum = (int) FleetStatusEnum.Status.Active;
            return _dbContext.Fleet.Where(x => x.CommanderId == characterid && x.State == activeenum).ToList().Any();
            
        }
    }
}
