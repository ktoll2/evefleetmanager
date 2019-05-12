using EveFleetManager.Repositories.Interfaces;
using EveFleetManager.Services;
using EveFleetManager.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace EveFleetManager.Test.Services
{
    [TestFixture]
    public class CharacterServiceTest
    {
        private Mock<ICharacterRepository> _characterRepository;
        private ICharacterService _characterService;

        [SetUp]
        public void Setup()
        {
            _characterRepository = new Mock<ICharacterRepository>();
            _characterService= new CharacterService(_characterRepository.Object);

        }

    }
}
