using LNHSApp.Domain.Filters;
using LNHSApp.Models.PlayersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.PlayersViewModels
{
    public class PlayersViewModel
    {
        public PlayerFilter Filter { get; set; }
        public ICollection<PlayerViewModel> PlayersList { get; set; }
    }
}