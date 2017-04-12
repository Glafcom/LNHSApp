using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Store : BaseModel
    {
        public Guid DetailId { get; set; }
        public int Count { get; set; }
        public virtual Detail Detail { get; set; }
    }
}
