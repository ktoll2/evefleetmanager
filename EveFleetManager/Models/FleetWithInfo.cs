using System;
using System.Collections.Generic;


namespace EveFleetManager.Models
{
    public class FleetWithInfo
    {
        public FleetWithInfo()
        {
            Id = -1;
            Description = string.Empty;
            FleetBossCharacterId = -1;
            FleetBossName = string.Empty;
            FleetCharacters = new List<FleetCharacter>();
            Status = new FleetStatusEnum();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int FleetBossCharacterId { get; set; }
        public string FleetBossName { get; set; }
        public List<FleetCharacter> FleetCharacters { get; set; }
        public FleetStatusEnum Status { get; set; }
    }
}
