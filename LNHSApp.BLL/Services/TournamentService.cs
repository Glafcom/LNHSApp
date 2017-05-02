using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Contracts.DALContracts;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Services
{
    public class TournamentService : BaseService<Tournament>, ITournamentService
    {
        protected readonly IUserService _userService;
        
        public TournamentService(IGenericRepository<Tournament> itemRepository, IUserService userService)
            : base(itemRepository)
        {
            _userService = userService;
        }

        public IEnumerable<Tournament> GetTournamentsByFilter(TournamentFilter filter)
        {
            var tournaments = GetItems();

            if (!string.IsNullOrEmpty(filter.Name))
                tournaments = tournaments.Where(t => t.Name.Contains(filter.Name));

            if (filter.PeriodStartDate.HasValue)
                tournaments = tournaments.Where(t => t.BeginDate >= filter.PeriodStartDate);

            if (filter.PeriodEndDate.HasValue)
                tournaments = tournaments.Where(t => t.BeginDate <= filter.PeriodEndDate);

            if (filter.Serie.HasValue)
                tournaments = tournaments.Where(t => t.SerieId == filter.Serie);

            if (!string.IsNullOrEmpty(filter.Country))
                tournaments = tournaments.Where(t => t.Country.Contains(filter.Country));

            if (!string.IsNullOrEmpty(filter.City))
                tournaments = tournaments.Where(t => t.City.Contains(filter.City));

            if (filter.Type.HasValue)
                tournaments = tournaments.Where(t => t.Type == filter.Type);

            return tournaments;
        }

        public IEnumerable<Tournament> GetUpcomingTournaments()
        {
            return GetItems().Where(t => t.BeginDate.Date > DateTime.Now.Date);
        }

        public IEnumerable<Tournament> GetUpcomingTournamentsByFilter(TournamentFilter filter)
        {
            return GetTournamentsByFilter(filter).Where(t => t.BeginDate.Date > DateTime.Now.Date);
        }

        public IEnumerable<Tournament> GetPastTournaments()
        {
            return GetItems().Where(t => t.EndDate.HasValue && ((DateTime)t.EndDate).Date < DateTime.Now.Date);
        }

        public IEnumerable<Tournament> GetPastTournamentsByFilter(TournamentFilter filter)
        {
            return GetTournamentsByFilter(filter).Where(t => t.EndDate.HasValue && ((DateTime)t.EndDate).Date < DateTime.Now.Date);
        }

        public IEnumerable<Tournament> GetCurrentTournaments()
        {
            return GetItems().Where(t => t.BeginDate.Date <= DateTime.Now.Date 
                                        && (t.EndDate.HasValue || ((DateTime)t.EndDate).Date >= DateTime.Now.Date));
        }

        public IEnumerable<Tournament> GetCurrentTournamentsByFilter(TournamentFilter filter)
        {
            return GetTournamentsByFilter(filter).Where(t => t.BeginDate.Date <= DateTime.Now.Date
                                        && (t.EndDate.HasValue || ((DateTime)t.EndDate).Date >= DateTime.Now.Date));
        }

        public IEnumerable<Tournament> GetSubscribedTournaments(Guid playerId)
        {
            return GetItems().Where(t => t.Players.Select(p => p.Id).Contains(playerId));
        }

        public IEnumerable<Tournament> GetSubscribedTournamentsByFilter(Guid playerId, TournamentFilter filter)
        {
            return GetTournamentsByFilter(filter).Where(t => t.Players.Select(p => p.Id).Contains(playerId));
        }

        public IEnumerable<Tournament> GetSubscribedPastTournaments(Guid playerId)
        {
            return GetSubscribedTournaments(playerId).Where(st => st.EndDate.HasValue && ((DateTime)st.EndDate).Date < DateTime.Now.Date);
        }

        public IEnumerable<Tournament> GetSubscribedPastTournamentsByFilter(Guid playerId, TournamentFilter filter)
        {
            return GetSubscribedTournamentsByFilter(playerId, filter).Where(st => st.EndDate.HasValue && ((DateTime)st.EndDate).Date < DateTime.Now.Date);
        }

        public IEnumerable<Tournament> GetSubscribedCurrentTournaments(Guid playerId)
        {
            return GetSubscribedTournaments(playerId).Where(st => st.BeginDate.Date <= DateTime.Now.Date
                                        && (st.EndDate.HasValue || ((DateTime)st.EndDate).Date >= DateTime.Now.Date));
        }

        public IEnumerable<Tournament> GetSubscribedCurrentTournamentsByFilter(Guid playerId, TournamentFilter filter)
        {
            return GetSubscribedTournamentsByFilter(playerId, filter).Where(st => st.BeginDate.Date <= DateTime.Now.Date
                                        && (st.EndDate.HasValue || ((DateTime)st.EndDate).Date >= DateTime.Now.Date));
        }

        public IEnumerable<Tournament> GetSubscribedUpcomingTournaments(Guid playerId)
        {
            return GetSubscribedTournaments(playerId).Where(st => st.BeginDate.Date > DateTime.Now.Date);
        }

        public IEnumerable<Tournament> GetSubscribedUpcomingTournamentsByFilter(Guid playerId, TournamentFilter filter)
        {
            return GetSubscribedTournamentsByFilter(playerId, filter).Where(st => st.BeginDate.Date > DateTime.Now.Date);
        }

        public IEnumerable<Tournament> GetOwnTournaments(Guid userId)
        {
            return GetItems().Where(t => t.CreatedById == userId);
        }

        public IEnumerable<Tournament> GetOwnTournamentsByFilter(Guid userId, TournamentFilter filter)
        {
            return GetTournamentsByFilter(filter).Where(t => t.CreatedById == userId);
        }

        public Tournament GetTournamentByStage(Guid stageId)
        {
            return GetItems().Where(t => t.Stages.Select(s => s.Id).Contains(stageId)).FirstOrDefault();
        }

        public void SubscribeToTournament(Guid userId, Guid tournamentId)
        {
            var tournament = GetItem(tournamentId);
            var user = _userService.GetItem(userId);

            if (tournament != null && user != null)
            {
                tournament.Players.Add(user);
                ChangeItem(tournamentId, tournament);
            }
        }

        public void UnsubscribeFromTournament(Guid userId, Guid tournamentId)
        {
            var tournament = GetItem(tournamentId);
            var user = _userService.GetItem(userId);
            if (tournament != null && user != null)
            {
                tournament.Players.Remove(user);
                ChangeItem(tournamentId, tournament);
            }
        }
    }
}
