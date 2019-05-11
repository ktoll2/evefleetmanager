using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveFleetManager.DataContext;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Services;
using EveFleetManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace EveFleetManager.Test.Services
{
    [TestFixture]
    public class CharacterServiceTest
    {
        private DbContextOptions<EveFleetManagerContext> _options;
        private EveFleetManagerContext _dbContext;
        private ICharacterService _characterService;

        private long _id1;
        private string _name1;

        private long _id2;
        private string _name2;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<EveFleetManagerContext>()
                .UseInMemoryDatabase(databaseName: "EveFleetManager")
                .Options;
            _dbContext = new EveFleetManagerContext(_options);
            _characterService= new CharacterService(_dbContext);

            InsertData();
        }

        private void InsertData()
        {
            _id1 = Faker.RandomNumber.Next(1, 5000);
            _name1 = Faker.Name.First();

             _id2 = Faker.RandomNumber.Next(1, 5000);
            _name2 = Faker.Name.First();

            List<Character> expectedCharacters = new List<Character>()
            {
                new Character(){ Id = _id1, Name = _name1},
                new Character(){ Id = _id2, Name = _name2},
            };
            _dbContext.AddRange(expectedCharacters);
            _dbContext.SaveChanges();
        }

        [Test]
        public void CharacterService_Implements()
        {
            Assert.IsTrue(typeof(ICharacterService).IsAssignableFrom(typeof(CharacterService)));
        }

        [Test]
        public void GetCharacter_ReturnsFirstCharacter_WhenInvoked()
        {
            var result = _characterService.GetCharacter(_id1);

            Assert.IsNotNull(result);
            Assert.AreEqual(_name1, result.Name);
        }

        [Test]
        public void GetCharacter_ReturnsSecondCharacter_WhenInvoked()
        {
            var result = _characterService.GetCharacter(_id2);

            Assert.IsNotNull(result);
            Assert.AreEqual(_name2, result.Name);
        }
    }
}
