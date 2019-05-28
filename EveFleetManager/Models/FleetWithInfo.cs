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

        public int Id;
        public string Description;
        public int FleetBossCharacterId;
        public string FleetBossName;
        public List<FleetCharacter> FleetCharacters;
        public FleetStatusEnum Status;
    }
}
