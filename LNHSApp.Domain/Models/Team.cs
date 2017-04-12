using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Team : BaseModel
    {
        public Team()
        {
            this.Players = new HashSet<User>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Players { get; set; }
    }
}
