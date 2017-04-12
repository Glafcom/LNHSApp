using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class PlayoffStage : BaseModel
    {
        public Guid StageId { get; set; }
        public int CompetitorsCount { get; set; }
        public string PlayoffFormula { get; set; }
        public bool? HasThirdPlaceGame { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
