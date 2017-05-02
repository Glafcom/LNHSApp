using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Services
{
    public interface ITournamentService : IBaseService<Tournament>
    {
        IEnumerable<Tournament> GetTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetUpcomingTournaments();
        IEnumerable<Tournament> GetUpcomingTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetPastTournaments();
        IEnumerable<Tournament> GetPastTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetCurrentTournaments();
        IEnumerable<Tournament> GetCurrentTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetSubscribedTournaments(Guid playerId);
        IEnumerable<Tournament> GetSubscribedTournamentsByFilter(Guid playerId, TournamentFilter filter);
        IEnumerable<Tournament> GetSubscribedPastTournaments(Guid playerId);
        IEnumerable<Tournament> GetSubscribedPastTournamentsByFilter(Guid playerId, TournamentFilter filter);
        IEnumerable<Tournament> GetSubscribedCurrentTournaments(Guid playerId);
        IEnumerable<Tournament> GetSubscribedCurrentTournamentsByFilter(Guid playerId, TournamentFilter filter);
        IEnumerable<Tournament> GetSubscribedUpcomingTournaments(Guid playerId);
        IEnumerable<Tournament> GetSubscribedUpcomingTournamentsByFilter(Guid playerId, TournamentFilter filter);
        IEnumerable<Tournament> GetOwnTournaments(Guid userId);
        IEnumerable<Tournament> GetOwnTournamentsByFilter(Guid userId, TournamentFilter filter);
        Tournament GetTournamentByStage(Guid stageId);
        void SubscribeToTournament(Guid userId, Guid tournamentId);
        void UnsubscribeFromTournament(Guid userId, Guid tournamentId);

    }
}
