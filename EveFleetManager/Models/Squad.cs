using EveFleetManager.DataContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Models
{
    public class Squad
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int SquadommanderId { get; set; }
        public String SquadCommanderName { get; set; }
        public List<Character> SquadMembers { get; set; }
    }
}
