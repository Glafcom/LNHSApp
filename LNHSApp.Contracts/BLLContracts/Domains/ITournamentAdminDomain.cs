using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Domains 
{
    public interface ITournamentAdminDomain
    {
        IEnumerable<Tournament> GetTournaments();
        IEnumerable<Tournament> GetTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetOwnTournaments();
        IEnumerable<Tournament> GetOwnTournamentsByFilter(TournamentFilter filter);
        Tournament GetTournament(Guid tournamentId);
        void CreateTournament(Tournament tournament);
        void EditTournament(Tournament tournament);
        void DeleteTournament(Guid tournamentId);
    }
}
