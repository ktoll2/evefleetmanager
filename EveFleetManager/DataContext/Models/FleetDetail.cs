using System;

namespace EveFleetManager.DataContext.Models
{
    public partial class FleetDetail
    {
        public long CharacterId { get; set; }
        public Guid FleetId { get; set; }
        public string Ship { get; set; }
        public DateTime TimeJoined { get; set; }
        public bool RemovedFromFleet { get; set; }
        public decimal SharePercentage { get; set; }
        public string CommanderComments { get; set; }

        public virtual Character Character { get; set; }
        public virtual Fleet Fleet { get; set; }
    }
}
