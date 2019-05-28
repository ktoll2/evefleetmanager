using System;
using System.Collections.Generic;

namespace EveFleetManager.DataContext.Models
{
    public partial class Fleet
    {
        public Fleet()
        {
            FleetDetail = new HashSet<FleetDetail>();
        }

        public Guid Id { get; set; }
        public string Desctiption { get; set; }
        public long CommanderId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int State { get; set; }
        public string Comment { get; set; }

        public  Character Commander { get; set; }
        public  ICollection<FleetDetail> FleetDetail { get; set; }
    }
}
