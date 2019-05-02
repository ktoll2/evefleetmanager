using System;
using System.Collections.Generic;

namespace EveFleetManager.DataContext.Models
{
    public partial class Character
    {
        public Character()
        {
            Fleet = new HashSet<Fleet>();
            FleetDetail = new HashSet<FleetDetail>();
        }

        public long Id { get; set; }
        public string RefreshToken { get; set; }
        public string BearerToken { get; set; }
        public DateTime TokenExpires { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Fleet> Fleet { get; set; }
        public virtual ICollection<FleetDetail> FleetDetail { get; set; }
    }
}
