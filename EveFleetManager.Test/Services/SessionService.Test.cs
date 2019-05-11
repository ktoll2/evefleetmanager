using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Services;
using EveFleetManager.Services.Interfaces;
using KellermanSoftware.CompareNetObjects;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveFleetManager.Test.Services
{
    [TestFixture]
    public class SessionServiceTest
    {
        private DbContextOptions<EveFleetManagerContext> _options;
        private EveFleetManagerContext _dbContext;
        private ISessionService _sessionService;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<EveFleetManagerContext>()
                .UseInMemoryDatabase(databaseName: "EveFleetManager")
                .Options;
            _dbContext = new EveFleetManagerContext(_options);
            _sessionService = new SessionService(_dbContext);
        }

        [Test]
        public void CreateSession_Creates_WhenInvoked()
        {
            int characterId = Faker.RandomNumber.Next(1, 9999);

            var result = _sessionService.CreateSession(characterId);

            var data = _dbContext.Session.FirstOrDefault(x=>x.CharacterId == characterId);

            CompareLogic compare = new CompareLogic();
            compare.Config.MaxMillisecondsDateDifference = 5000;
            var compResult = compare.Compare(data, result);

            Assert.IsTrue(compResult.AreEqual);

            Assert.AreNotEqual(new Guid().ToString(), result.SessionId);

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

            var result = _sessionService.GetSessionByCharacterId(characterId);

            CompareLogic compare = new CompareLogic();
            compare.Config.MaxMillisecondsDateDifference = 5000;
            var compResult = compare.Compare(result, expectedSession);

            Assert.IsTrue(compResult.AreEqual);

        }
    }
}
