using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.PlayersViewModels
{
    public class PlayerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Raiting { get; set; }
        
    }

    public class PlayerRatingViewModel
    { 
        public string TournamentName { get; set; }
        public int Rate { get; set; }
    }

}