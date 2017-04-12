using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Game : BaseModel
    {
        public int Order { get; set; }

        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? IsOvertime { get; set; }

        public Guid? StageId { get; set; }
        public Guid? HomePlayerId { get; set; }
        public Guid? GuestPlayerId { get; set; }
        public int? HomeScore { get; set; }
        public int? GuestScore { get; set; }
        public Guid? HockeyTableId { get; set; }

        public virtual Stage Stage { get; set; }
        public virtual User HomePlayer { get; set; }
        public virtual User GuestPlayer { get; set; }
        public virtual HockeyTable HockeyTable { get; set; }

    }
}
