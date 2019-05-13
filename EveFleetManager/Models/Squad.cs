using EveFleetManager.DataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Models
{
    public class Squad
    {
        public int Id;
        public int Name;
        public int SquadommanderId;
        public String SquadCommanderName;
        public List<Character> SquadMembers;
    }
}
