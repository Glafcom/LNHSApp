using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Domains 
{
    public interface ISupervisorDomain
    {
        IEnumerable<Serie> GetSeries();

        IEnumerable<Tournament> GetTournaments();
        IEnumerable<Tournament> GetTournamentsByFilter(TournamentFilter filter);
        IEnumerable<Tournament> GetOwnTournaments();
        IEnumerable<Tournament> GetOwnTournamentsByFilter(TournamentFilter filter);
        Tournament GetTournament(Guid tournamentId);
        Tournament CreateTournament(Tournament tournament);
        void EditTournament(Tournament tournament);
        void DeleteTournament(Guid tournamentId);


        Stage GetStage(Guid stageId);
        Stage CreateStage(Stage stage);
        PlayoffStage GetPlayoffStage(Guid poStageId);
        void CreatePlayoffStage(PlayoffStage playoffStage);
        RoundRobinStage GetRoundRobinStage(Guid rrStageId);
        void CreateRoundRobinStage(RoundRobinStage roundRobinStage);
        
        

        /*void CreateRoundRobinStage(RoundRobinStage stage);
        void EditRoundRobinStage(RoundRobinStage stage);
        void DeleteRoundRobinStage(Guid stageId);

        void CreatePlayoffStage(PlayoffStage stage);
        void EditPlayoffStage(PlayoffStage stage);
        void DeletePlayoffStage(Guid stageId);*/
    }
}
