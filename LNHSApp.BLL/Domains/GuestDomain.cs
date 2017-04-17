using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Domains
{
    public class GuestDomain : IGuestDomain
    {
        protected readonly ITournamentService _tournamentService;

        public GuestDomain(ITournamentService tournamentService)
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

        public IEnumerable<Tournament> GetPastTournaments()
        {
            return _tournamentService.GetPastTournaments();
        }

        public IEnumerable<Tournament> GetPastTournamentsByFilter(TournamentFilter filter)
        {
            return _tournamentService.GetPastTournamentsByFilter(filter);
        }

        public IEnumerable<Tournament> GetCurrentTournaments()
        {
            return _tournamentService.GetCurrentTournaments();
        }

        public IEnumerable<Tournament> GetCurrentTournamentsByFilter(TournamentFilter filter)
        {
            return _tournamentService.GetCurrentTournamentsByFilter(filter);
        }

        public IEnumerable<Tournament> GetUpcomingTournaments()
        {
            return _tournamentService.GetUpcomingTournaments();
        }

        public IEnumerable<Tournament> GetUpcomingTournamentsByFilter(TournamentFilter filter)
        {
            return _tournamentService.GetUpcomingTournamentsByFilter(filter);
        }

        public Tournament GetTournament(Guid tournamentId)
        {
            return _tournamentService.GetItem(tournamentId);
        }

        #endregion
    }
}
