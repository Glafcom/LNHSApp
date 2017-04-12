using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class RoundRobinStage :BaseModel
    {
        public Guid StageId { get; set; }
        public int RoundsCount { get; set; }
        public string ScoresFormula { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
