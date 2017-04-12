using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Serie : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Tournament> Tournaments { get; set; } 
    }
}
