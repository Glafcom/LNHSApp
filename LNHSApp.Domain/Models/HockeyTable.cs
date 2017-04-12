using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class HockeyTable : BaseModel
    {
        public string Code { get; set; }
        public TableCondition Condition { get; set; }
        public Guid OwnerId { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
