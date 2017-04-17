using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Player.Models.TournamentsViewModels
{
    public class BaseTournamentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Serie { get; set; }
        public bool? IsTeam { get; set; }
        public int SubscribedPlayersCount { get; set; }
        public TournamentCreator Creator { get; set; }

    }

    public class TournamentCreator
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}