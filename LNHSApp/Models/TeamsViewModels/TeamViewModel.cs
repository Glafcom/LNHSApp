using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.TeamsViewModels
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public ICollection<TeamPlayer> Players { get; set; }
    }

    public class TeamPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Raiting { get; set; }
    }
}