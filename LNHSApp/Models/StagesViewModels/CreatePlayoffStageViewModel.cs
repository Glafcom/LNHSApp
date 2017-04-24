using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.StagesViewModels
{
    public class CreatePlayoffStageViewModel
    {
        public Guid Id { get; set; }
        public int CompetitorsCount { get; set; }
        public string PlayoffFormula { get; set; }
        public bool? HasThirdPlaceGame { get; set; }
        
    }
}