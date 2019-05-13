using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Models
{
    public class FleetWithInfo
    {
        public FleetWithInfo()
        {
            Id = -1;
            Name = string.Empty;
            FleetCommanderId = -1;
            FleetCommanderName = string.Empty;
            Wings = new List<Wing>();
            Status = new FleetStatusEnum();
        }
        public int Id;
        public string Name;
        public int FleetCommanderId;
        public String FleetCommanderName;
        public List<Wing> Wings;
        public FleetStatusEnum Status;
    }
}
