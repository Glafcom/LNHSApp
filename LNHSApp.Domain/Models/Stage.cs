using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Stage
    {
        public Stage()
        {
            this.Tables = new HashSet<HockeyTable>();
            this.Players = new HashSet<User>();
            this.Teams = new HashSet<Team>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; } 

        public virtual ICollection<HockeyTable> Tables { get; set; }
        public virtual ICollection<User> Players { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
