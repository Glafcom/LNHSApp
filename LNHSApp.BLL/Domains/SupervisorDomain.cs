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
    public class SupervisorDomain : User, ISupervisorDomain
    {
        protected readonly ITournamentService _tournamentService;
        protected readonly ISerieService _serieService;
        protected readonly IStageService _stageService;

        public SupervisorDomain(ITournamentService tournamentService, 
            ISerieService serieService,
            IStageService stageService)
        {
            _tournamentService = tournamentService;
            _serieService = serieService;
            _stageService = stageService;
        }

        #region Series methods

        public IEnumerable<Serie> GetSeries()
        {
            return _serieService.GetItems();
        }

        #endregion

        #region Tournaments methods

        public IEnumerable<Tournament> GetTournaments()
        {
            return _tournamentService.GetItems();
        }

        public IEnumerable<Tournament> GetTournamentsByFilter(TournamentFilter filter)
        {
            return _tournamentService.GetTournamentsByFilter(filter);
        }

        public IEnumerable<Tournament> GetOwnTournaments()
        {
            return _tournamentService.GetOwnTournaments(Id);
        }

        public IEnumerable<Tournament> GetOwnTournamentsByFilter(TournamentFilter filter)
        {
            return _tournamentService.GetOwnTournamentsByFilter(Id, filter);
        }

        public Tournament GetTournament(Guid tournamentId)
        {
            return _tournamentService.GetItem(tournamentId);
        }

        public Tournament GetTournamentByStage(Guid stageId)
        {
            return _tournamentService.GetTournamentByStage(stageId);
        }

        public Tournament CreateTournament(Tournament tournament)
        {
            return _tournamentService.AddItem(tournament);
        }

        public void EditTournament(Tournament tournament)
        {
            _tournamentService.ChangeItem(tournament.Id, tournament);
        }

        public void DeleteTournament(Guid tournamentId)
        {
            _tournamentService.DeleteItem(tournamentId);
        }

        #endregion

        #region Stage methods

        public Stage GetStage(Guid stageId)
        {
            return _stageService.GetItem(stageId);
        }

        public Stage CreateStage(Stage stage)
        {
            return _stageService.AddItem(stage);
        }

        public void EditStage(Stage stage)
        {
            _stageService.ChangeItem(stage.Id, stage);
        }

        public void DeleteStage(Guid stageId)
        {
            _stageService.DeleteStagesOfGeneralStage(stageId);
            _stageService.DeleteItem(stageId);
        }

        public PlayoffStage GetPlayoffStageByGeneralStage(Guid stageId)
        {
            return _stageService.GetPlayoffStageByGeneralStage(stageId);
        }

        public void CreatePlayoffStage(PlayoffStage playoffStage)
        {
            _stageService.CreatePlayoffStage(playoffStage);
        }

        public RoundRobinStage GetRoundRobinStageByGeneralStage(Guid stageId)
        {
            return _stageService.GetRRStageByGeneralStage(stageId);
        }

        public void CreateRoundRobinStage(RoundRobinStage roundRobinStage)
        {
            _stageService.CreateRoundRobinStage(roundRobinStage);
        }

        public void DeleteStagesOfGeneralStage(Guid stageId)
        {
            _stageService.DeleteStagesOfGeneralStage(stageId);
        }

        #endregion
    }
}
