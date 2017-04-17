using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.TournamentsViewModels
{
    public class CreateTournamentViewModel
    {
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime StartRegistrationDate { get; set; }
        public DateTime EndRegistrationDate { get; set; }
        public Guid? SerieId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool? IsTeamTournament { get; set; }
        public string Description { get; set; }        
    }
}