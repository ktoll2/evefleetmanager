using System;
using System.Collections.Generic;

namespace EveFleetManager.DataContext.Models
{
    public partial class User
    {
        public User()
        {
            Fleet = new HashSet<Fleet>();
            FleetDetail = new HashSet<FleetDetail>();
        }

        public long CharacterId { get; set; }
        public string RefreshToken { get; set; }
        public string BearerToken { get; set; }
        public DateTime TokenExpires { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Fleet> Fleet { get; set; }
        public virtual ICollection<FleetDetail> FleetDetail { get; set; }
    }
}
