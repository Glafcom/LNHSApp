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
    public class GuestDomain : IGuestDomain
    {
        protected readonly ITournamentService _tournamentService;
        protected readonly ITeamService _teamService;
        protected readonly IUserService _userService;

        public GuestDomain(ITournamentService tournamentService,
            ITeamService teamService,
            IUserService userService)
        {
            _tournamentService = tournamentService;
            _teamService = teamService;
            _userService = userService;
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

        #region Teams methods

        public IEnumerable<Team> GetTeams()
        {
            return _teamService.GetItems();
        }

        public IEnumerable<Team> GetTeamsByFilter(TeamFilter filter)
        {
            return _teamService.GetTeamsByFilter(filter);
        }

        public Team GetTeam(Guid teamId)
        {
            return _teamService.GetItem(teamId);
        }

        #endregion

        #region Players methods

        public IEnumerable<User> GetPlayers()
        {
            return _userService.GetPlayers();
        }

        public IEnumerable<User> GetPlayersByFilter(PlayerFilter filter)
        {
            return _userService.GetPlayersByFilter(filter);
        }

        public User GetPlayer(Guid playerId)
        {
            return _userService.GetPlayer(playerId);
        }

        #endregion
    }
}
