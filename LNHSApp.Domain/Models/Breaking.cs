using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Breaking : BaseModel
    {
        public Breaking()
        {
            this.Guilties = new HashSet<User>();
        }
        public string Description { get; set; }
        public Guid? DetailId { get; set; }
        public Guid? HockeyTableId { get; set; }
        public Guid? GameId { get; set; }
        public Guid? ResolvedWithOrderId { get; set; }
        public bool? IsResolved { get; set; }

        public virtual Detail Detail { get; set; }
        public virtual Game Game { get; set; }
        public virtual HockeyTable HockeyTable { get; set; }
        public virtual Order ResolvedWithOrder { get; set; }
        public virtual ICollection<User> Guilties { get; set; }
    }
}
