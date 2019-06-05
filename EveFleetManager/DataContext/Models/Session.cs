using System;

namespace EveFleetManager.DataContext.Models
{
    public partial class Session
    {
        public long CharacterId { get; set; }
        public string SessionId { get; set; }
        public DateTime SessionExpires { get; set; }
    }
}
