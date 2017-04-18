using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Supervisor.Models.TournamentsViewModels
{
    public class IndexViewModel
    {
        public ICollection<BaseTournamentViewModel> AllTournaments { get; set; }
        public ICollection<BaseTournamentViewModel> PastTournaments { get; set; }
        public ICollection<BaseTournamentViewModel> CurrentTournaments { get; set; }
        public ICollection<BaseTournamentViewModel> UpcomingTournaments { get; set; }
    }
}