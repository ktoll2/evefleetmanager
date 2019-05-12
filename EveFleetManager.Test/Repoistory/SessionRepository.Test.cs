using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Repositories;
using EveFleetManager.Repositories.Interfaces;
using KellermanSoftware.CompareNetObjects;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace EveFleetManager.Test.Repositories
{
    [TestFixture]
    public class SessionRepositoryTest
    {
        private DbContextOptions<EveFleetManagerContext> _options;
        private EveFleetManagerContext _dbContext;
        private ISessionRepository _sessionRepository;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<EveFleetManagerContext>()
                .UseInMemoryDatabase(databaseName: "EveFleetManager")
                .Options;
            _dbContext = new EveFleetManagerContext(_options);
            _sessionRepository = new SessionRepository(_dbContext);
        }

        [Test]
        public void CreateSession_Creates_WhenInvoked()
        {
            int characterId = Faker.RandomNumber.Next(1, 9999);
            string guid = Guid.NewGuid().ToString();
            DateTime expires = DateTime.UtcNow.AddHours(2);

            Session expectedSession = new Session()
            {
                CharacterId = characterId,
                SessionExpires = expires,
                SessionId = guid
            };

            var result = _sessionRepository.CreateSession(expectedSession);

            var data = _dbContext.Session.FirstOrDefault(x=>x.CharacterId == characterId);

            CompareLogic compare = new CompareLogic();
            compare.Config.MaxMillisecondsDateDifference = 5000;
            var compResult = compare.Compare(data, result);

            Assert.IsTrue(compResult.AreEqual);
        }

        [Test]
        public void GetSessionByCharacterId_ReturnsSession_WhenInvoked()
        {
            int characterId = Faker.RandomNumber.Next(1, 9999);
            string guid = Guid.NewGuid().ToString();
            DateTime expires = DateTime.UtcNow.AddHours(2);

            Session expectedSession = new Session()
            {
                CharacterId = characterId,
                SessionExpires = expires,
                SessionId = guid
            };

            _dbContext.Session.Add(expectedSession);
            _dbContext.SaveChanges();

            var result = _sessionRepository.GetSessionByCharacterId(characterId);

            CompareLogic compare = new CompareLogic();
            compare.Config.MaxMillisecondsDateDifference = 5000;
            var compResult = compare.Compare(result, expectedSession);

            Assert.IsTrue(compResult.AreEqual);

        }

        [Test]
        public void GetSessionBySessionId_ReturnsSession_WhenInvoked()
        {
            int characterId = Faker.RandomNumber.Next(1, 9999);
            string guid = Guid.NewGuid().ToString();
            DateTime expires = DateTime.UtcNow.AddHours(2);

            Session expectedSession = new Session()
            {
                CharacterId = characterId,
                SessionExpires = expires,
                SessionId = guid
            };

            _dbContext.Session.Add(expectedSession);
            _dbContext.SaveChanges();

            var result = _sessionRepository.GetSessionBySessionId(guid);

            CompareLogic compare = new CompareLogic();
            compare.Config.MaxMillisecondsDateDifference = 5000;
            var compResult = compare.Compare(result, expectedSession);

            Assert.IsTrue(compResult.AreEqual);

        }
    }
}
