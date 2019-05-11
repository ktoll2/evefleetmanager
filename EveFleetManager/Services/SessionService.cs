using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Services
{
    public class SessionService : ISessionService
    {
        private EveFleetManagerContext _dbContext;

        public SessionService(EveFleetManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Session CreateSession(int characterId)
        {
            Session session = new Session()
            {
                CharacterId = characterId,
                SessionExpires = DateTime.UtcNow.AddHours(2),
                SessionId = Guid.NewGuid().ToString()
            };
            _dbContext.Session.Add(session);
            _dbContext.SaveChanges();
            return session;
        }

        public Session GetSessionByCharacterId(int characterId)
        {
            return _dbContext.Session.FirstOrDefault(x => x.CharacterId == characterId);
        }
    }
}
