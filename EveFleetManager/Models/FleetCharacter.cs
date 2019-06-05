using System;

namespace EveFleetManager.Models
{
    public class FleetCharacter
    {
        string Name { get; set; }
        string Id { get; set; }
        DateTime DateJoined { get; set; }
        bool RemovedFromFleet { get; set; }
        decimal SharePercentage { get; set; }
        string Comments { get; set; }
        string ShipType { get; set; }

    }
}