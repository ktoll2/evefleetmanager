using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Repositories.Interfaces;
using EveFleetManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Services
{
    public class SessionService : ISessionService
    {
        private ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public Session CreateSession(int characterId)
        {
            Session session = new Session()
            {
                CharacterId = characterId,
                SessionExpires = DateTime.UtcNow.AddHours(2),
                SessionId = Guid.NewGuid().ToString()
            };

            return _sessionRepository.CreateSession(session);
        }

        public Session GetSessionByCharacterId(int characterId)
        {
            return _sessionRepository.GetSessionByCharacterId(characterId);
        }

        public Session GetSessionBySessionId(string sessionId)
        {
            return _sessionRepository.GetSessionBySessionId(sessionId);
        }

        public bool IsSessionValid(string sessionId)
        {
            var session = _sessionRepository.GetSessionBySessionId(sessionId);

            return session?.SessionExpires > DateTime.UtcNow;
        }
    }
}
