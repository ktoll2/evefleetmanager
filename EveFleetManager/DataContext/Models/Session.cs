using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.DataContext.Models
{
    public class Session
    {
        public long characterId { get; set; }
        public DateTime sessionExpires { get; set; }
        public string sessionId { get; set; }

    }
}
