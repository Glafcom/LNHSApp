using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Domains
{
    public interface IGuestDomain
    {
        IEnumerable<Tournament> GetTournaments();
        IEnumerable<Tournament> GetTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetPastTournaments();
        IEnumerable<Tournament> GetPastTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetCurrentTournaments();
        IEnumerable<Tournament> GetCurrentTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetUpcomingTournaments();
        IEnumerable<Tournament> GetUpcomingTournamentsByFilter(TournamentFilter filter);

        Tournament GetTournament(Guid tournamentId);
    }
}
