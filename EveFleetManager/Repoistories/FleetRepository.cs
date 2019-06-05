using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Models;
using EveFleetManager.Repositories.Interfaces;
using System;
using System.Linq;


namespace EveFleetManager.Repositories
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

        public Fleet CreateNewFleet(long characterId)
        {
            int activeenum = (int)FleetStatusEnum.Status.Active;

            Fleet fleet = new Fleet()
            {
                Id = Guid.NewGuid(),
                Desctiption = "",
                CommanderId = characterId,
                StartTime = DateTime.Now,
                State = activeenum
            };

            _dbContext.Add(fleet);
            _dbContext.SaveChanges();
            return fleet;
        }

        public void EndActiveFleet(long characterId)
        {
            int activeenum = (int)FleetStatusEnum.Status.Active;

            var ActiveFleet =
                _dbContext.Fleet.Where(x => x.CommanderId == characterId && x.State == activeenum).ToList();

            if (ActiveFleet.Any())
            {
                ActiveFleet.ForEach(x => x.State = (int)FleetStatusEnum.Status.Ended);
            }
        }

        public Fleet GetCharactersActiveFleet(long characterId)
        {
            int activeenum = (int)FleetStatusEnum.Status.Active;

            return _dbContext.Fleet.FirstOrDefault(x => x.CommanderId == characterId && x.State == activeenum);
        }

    }
}
