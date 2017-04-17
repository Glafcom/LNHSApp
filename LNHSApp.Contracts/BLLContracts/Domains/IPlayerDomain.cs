using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Domains
{
    public interface IPlayerDomain
    {      
        IEnumerable<Tournament> GetSubscribedTournaments();
        IEnumerable<Tournament> GetSubscribedTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetSubscribedPastTournaments();
        IEnumerable<Tournament> GetSubscribedPastTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetSubscribedCurrentTournaments();
        IEnumerable<Tournament> GetSubscribedCurrentTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetSubscribedUpcomingTournaments();
        IEnumerable<Tournament> GetSubscribedUpcomingTournamentsByFilter(TournamentFilter filter);        
        void SubscribeToTournament(Guid tournamentId);
        void UnsubscribeFromTournament(Guid tournamentId);
    }
}