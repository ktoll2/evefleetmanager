using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Models
{
    public class Wing
    {
        
        public int Id;
        public int Name;
        public int WingCommanderId;
        public String WingCommanderName;
        public List<Squad> Squads;
    }
}
