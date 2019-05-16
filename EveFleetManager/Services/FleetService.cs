using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.SSO;
using EveFleetManager.Controllers.Interfaces;
using EveFleetManager.DataContext.Models;
using EveFleetManager.Models;
using EveFleetManager.Repoistory.Interface;
using EveFleetManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveFleetManager.Services
{
    public class FleetService : IFleetService
    {
        private IFleetRepository _fleetRepository;
        private IEsiClient _esiClient;
        private IAuthController _authController;
        public FleetService(IFleetRepository fleetRepository, IEsiClient esiClient,IAuthController authcontroller)
        {
            _esiClient = esiClient;
            _fleetRepository = fleetRepository;
            _authController = authcontroller;
        }

        public bool CharacterHasActiveFleet(long CharacterId)
        {

            return _fleetRepository.CharacterHasActiveFleet(CharacterId);
        }

        public FleetWithInfo StartFleet(Character character)
        {
            createEsiClient(character);
            var fleetinfo =  _esiClient.Fleets.FleetInfo().Result;

            
            
            var fleetmemberinfo = _esiClient.Fleets.Members(fleetinfo.Data.FleetId).Result;

            if (fleetmemberinfo.Data == null)
            {
                throw new Exception(fleetmemberinfo.Message);
            }


     

            return new FleetWithInfo();
        }

        public FleetWithInfo GetActiveFleet(Character character)
        {

            return new FleetWithInfo();
        }

         private void createEsiClient(Character character)
        {
            var token = _authController.Refresh(character.RefreshToken).Result;
            
            AuthorizedCharacterData authchar = new AuthorizedCharacterData();

            authchar.CharacterID = (int)character.Id;
            authchar.ExpiresOn = character.TokenExpires;
            authchar.RefreshToken = character.RefreshToken;
            authchar.Token = ;
            _esiClient.SetCharacterData(authchar);
          
          //  authchar.TokenType = GrantType.AuthorizationCode.ToString();
        }

    }
}
