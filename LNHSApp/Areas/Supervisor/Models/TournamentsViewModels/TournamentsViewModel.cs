using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Supervisor.Models.TournamentsViewModels
{
    public class TournamentsViewModel
    {
        public TournamentFilter Filter { get; set; }
        public ICollection<BaseTournamentViewModel> TournamentsList { get; set; }
    }
}