using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.TournamentsViewModels
{
    public class TournamentViewModel : BaseTournamentViewModel
    {
        public ICollection<TournamentPlayer> Players { get; set; }
        public ICollection<TournamentTeam> Teams { get; set; }
    }

    public class TournamentPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int Rating { get; set; }
    }

    public class TournamentTeam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }

    public class TournamentStage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}