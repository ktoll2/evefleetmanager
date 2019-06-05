using ESI.NET;
using ESI.NET.Models.SSO;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Helpers.Interfaces;
using EveFleetManager.Models;
using EveFleetManager.Repositories.Interfaces;
using EveFleetManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EveFleetManager.Services
{
    public class FleetService : IFleetService
    {
        private IFleetRepository _fleetRepository;
        private IEsiClient _esiClient;
        private IAuthService _authService;
        private ICharacterService _characterService;
        private IFleetWithInfoHelper _fleetCharacterHelper;
        private IFleetDetailsRepository _fleetDetailsRepository;

        public FleetService(IFleetRepository fleetRepository, 
            IEsiClient esiClient,
            IAuthService authservice,
            ICharacterService characterService,
            IFleetWithInfoHelper fleetCharacterHelper,
            IFleetDetailsRepository fleetDetailsRepository)
        {
            _esiClient = esiClient;
            _fleetRepository = fleetRepository;
            _authService = authservice;
            _characterService = characterService;
            _fleetCharacterHelper = fleetCharacterHelper;
            _fleetDetailsRepository = fleetDetailsRepository;
        }

        public bool CharacterHasActiveFleet(long CharacterId)
        {

            return _fleetRepository.CharacterHasActiveFleet(CharacterId);
        }

        public FleetWithInfo StartFleet(Session Session)
        {


            createEsiClient(Session);
            var fleetinfo =  _esiClient.Fleets.FleetInfo().Result;

           var fleetmemberinfo = _esiClient.Fleets.Members(fleetinfo.Data.FleetId).Result;

            if (fleetmemberinfo.Data == null)
            {
                throw new Exception(fleetmemberinfo.Message);
            }
            var fleetData = fleetmemberinfo.Data;

            _fleetRepository.EndActiveFleet(Session.CharacterId);

            //save all characters in fleet to our database and get the names back
            List<Character> characterList=
                _characterService.AddCharactorsToDatabaseIfNotAlready(fleetData);

            // save who is in fleet to database
            Fleet Fleetinfo = _fleetRepository
                .CreateNewFleet(Session.CharacterId);

            //save memebers to fleet detials

            List<FleetDetail> fleetDetail = new List<FleetDetail>();

            fleetDetail = fleetData.Select(x => new FleetDetail()
            {
                CharacterId=x.CharacterId,
                FleetId = Fleetinfo.Id,
                Ship = x.ShipTypeId.ToString(),
                TimeJoined = DateTime.Now,
                SharePercentage = 1.00m
                
            }).ToList();

            _fleetDetailsRepository.SaveFleetDetailsList(fleetDetail);

            var potato =_fleetRepository.GetCharactersActiveFleet(Session.CharacterId);


            return new FleetWithInfo();
        }

        public FleetWithInfo GetActiveFleet(Character character)
        {

            return new FleetWithInfo();
        }

         private void createEsiClient(Session session)
        {

            Character character= _characterService.GetCharacter(session.CharacterId);

            AuthorizedCharacterData authchar = 
                _authService.GetAuthorizedCharacterData(character.RefreshToken);

            _esiClient.SetCharacterData(authchar);
          

        }


    }
}
