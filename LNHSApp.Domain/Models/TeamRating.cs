using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class TeamRating : BaseModel
    {
        public Guid TeamId { get; set; }
        public Guid TournamentId { get; set; }
        public int Rate { get; set; }

        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
