using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Models
{
    public class Wing
    {
        
        public int Id { get; set; }
        public int Name { get; set; }
        public int WingCommanderId { get; set; }
        public String WingCommanderName { get; set; }
        public List<Squad> Squads { get; set; }
    }
}
