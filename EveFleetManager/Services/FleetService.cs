using ESI.NET;
using ESI.NET.Enumerations;
using ESI.NET.Models.SSO;
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
        public FleetService(IFleetRepository fleetRepository, IEsiClient esiClient)
        {
            _esiClient = esiClient;
            _fleetRepository = fleetRepository;
        }

        public bool CharacterHasActiveFleet(long CharacterId)
        {

            return _fleetRepository.CharacterHasActiveFleet(CharacterId);
        }

        public FleetWithInfo StartFleet(Character character)
        {
            createEsiClient(character);
            var potato =  _esiClient.Fleets.FleetInfo().Result;



     

            return new FleetWithInfo();
        }

        public FleetWithInfo GetActiveFleet(Character character)
        {

            return new FleetWithInfo();
        }

         private void createEsiClient(Character character)
        {

            AuthorizedCharacterData authchar = new AuthorizedCharacterData();
            authchar.CharacterID = (int)character.Id;
            authchar.ExpiresOn = character.TokenExpires;
            authchar.RefreshToken = character.RefreshToken;
            authchar.Token = character.BearerToken;
           
            _esiClient.SetCharacterData(authchar);
          //  authchar.TokenType = GrantType.AuthorizationCode.ToString();
        }

    }
}
