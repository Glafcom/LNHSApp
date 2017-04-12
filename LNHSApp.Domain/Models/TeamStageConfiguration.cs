using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class TeamStageConfiguration : BaseModel
    {
        public Guid? StageId { get; set; }
        public ScoreCountingSystem System { get; set; }

        public virtual Stage Stage { get; set; }
    }
}
