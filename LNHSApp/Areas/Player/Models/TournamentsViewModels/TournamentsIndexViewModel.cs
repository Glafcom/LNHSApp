using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Player.Models.TournamentsViewModels
{
    public class TournamentsIndexViewModel
    {
        public ICollection<BaseTournamentViewModel> SubsribedPastTournaments { get; set; }
        public ICollection<BaseTournamentViewModel> SubsribedCurrentTournaments { get; set; }
        public ICollection<BaseTournamentViewModel> SubsribedUpcomingTournaments { get; set; }
    }
}