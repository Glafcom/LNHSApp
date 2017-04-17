using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.TournamentsViewModels
{
    public class TournamentsIndexViewModel
    {
        public ICollection<BaseTournamentViewModel> AllTournaments { get; set; }
        public ICollection<BaseTournamentViewModel> PastTournaments { get; set; }
        public ICollection<BaseTournamentViewModel> CurrentTournaments { get; set; }
        public ICollection<BaseTournamentViewModel> UpcomingTournaments { get; set; }
    }
}