using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Rating : BaseModel
    {
        public Guid PlayerId { get; set; }
        public Guid TournamentId { get; set; }
        public int Rate { get; set; }

        public virtual User Player { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
