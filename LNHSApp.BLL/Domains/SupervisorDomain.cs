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

        public SupervisorDomain(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

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

        public void CreateTournament(Tournament tournament)
        {
            _tournamentService.AddItem(tournament);
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
    }
}
