using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Tournament : BaseModel
    {
        public Tournament()
        {
            this.Admins = new HashSet<User>();
            this.Players = new HashSet<User>();
            this.Teams = new HashSet<Team>();
            this.Stages = new HashSet<Stage>();
            this.Tables = new HashSet<HockeyTable>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime StartRegistrationDate { get; set; }
        public DateTime EndRegistrationDate { get; set; }
        public TournamentState State { get; set; }
        public Guid? SerieId { get; set; }
        public string Country { get; set; } 
        public string City { get; set; }
        public string Adress { get; set; }
        public Guid CreatedById { get; set; }
        public TournamentType Type { get; set; }

        public virtual Serie Serie { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual ICollection<User> Admins { get; set; }
        public virtual ICollection<User> Players { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Stage> Stages { get; set; }
        public virtual ICollection<HockeyTable> Tables { get; set; }
    }
}
