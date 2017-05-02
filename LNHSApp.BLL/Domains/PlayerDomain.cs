using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Domains
{
    public class PlayerDomain : User, IPlayerDomain
    {
        protected readonly ITournamentService _tournamentService;
        protected readonly IStageService _stageService;

        public PlayerDomain(ITournamentService tournamentService, IStageService stageService)
        {
            _tournamentService = tournamentService;
            _stageService = stageService;
        }

        #region Tournament methods
        
        public IEnumerable<Tournament> GetSubscribedTournaments()
        {
            return _tournamentService.GetSubscribedTournaments(Id);
        }

        public IEnumerable<Tournament> GetSubscribedTournamentsByFilter(TournamentFilter filter)
        {
            return _tournamentService.GetSubscribedTournamentsByFilter(Id, filter);
        }

        public IEnumerable<Tournament> GetSubscribedPastTournaments()
        {
            return _tournamentService.GetSubscribedPastTournaments(Id);
        }

        public IEnumerable<Tournament> GetSubscribedPastTournamentsByFilter(TournamentFilter filter)
        {
            return _tournamentService.GetSubscribedPastTournamentsByFilter(Id, filter);
        }

        public IEnumerable<Tournament> GetSubscribedCurrentTournaments()
        {
            return _tournamentService.GetSubscribedCurrentTournaments(Id);
        }

        public IEnumerable<Tournament> GetSubscribedCurrentTournamentsByFilter(TournamentFilter filter)
        {
            return _tournamentService.GetSubscribedCurrentTournamentsByFilter(Id, filter);
        }

        public IEnumerable<Tournament> GetSubscribedUpcomingTournaments()
        {
            return _tournamentService.GetSubscribedUpcomingTournaments(Id);
        }

        public IEnumerable<Tournament> GetSubscribedUpcomingTournamentsByFilter(TournamentFilter filter)
        {
            return _tournamentService.GetSubscribedUpcomingTournamentsByFilter(Id, filter);
        }

        public void SubscribeToTournament(Guid tournamentId)
        {
            _tournamentService.SubscribeToTournament(Id, tournamentId);
        }

        public void UnsubscribeFromTournament(Guid tournamentId)
        {
            _tournamentService.UnsubscribeFromTournament(Id, tournamentId);
        }

        #endregion

        #region Stages methods

        public Stage GetStage(Guid stageId)
        {
            return _stageService.GetItem(stageId);
        }

        public PlayoffStage GetPlayoffStageByGeneralStage(Guid stageId)
        {
            return _stageService.GetPlayoffStageByGeneralStage(stageId);
        }

        public RoundRobinStage GetRoundRobinStageByGeneralStage(Guid stageId)
        {
            return _stageService.GetRRStageByGeneralStage(stageId);
        }

        #endregion
    }
}
