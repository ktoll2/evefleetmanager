using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Repositories.Interfaces;
using System.Linq;

namespace EveFleetManager.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private EveFleetManagerContext _dbContext;

        public SessionRepository(EveFleetManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Session CreateSession(Session session)
        {
            RemoveSessionsByCharacterId(session.CharacterId);

            _dbContext.Session.Add(session);
            _dbContext.SaveChanges();
            return session;
        }

        public void RemoveSessionsByCharacterId(long characterId)
        {
            _dbContext.Session.RemoveRange(_dbContext.Session.Where(x => x.CharacterId == characterId).ToList());
            _dbContext.SaveChanges();
        }

        public Session GetSessionByCharacterId(int characterId)
        {
            return _dbContext.Session.FirstOrDefault(x => x.CharacterId == characterId);
        }

        public Session GetSessionBySessionId(string sessionId)
        {
            return _dbContext.Session.FirstOrDefault(x => x.SessionId == sessionId);
        }
    }
}