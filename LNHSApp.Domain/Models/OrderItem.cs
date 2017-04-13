using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class OrderItem : BaseModel
    {
        public Guid DetailId { get; set; }
        public int Count { get; set; }
        public Guid OrderId { get; set; }

        public virtual Detail Detail { get; set; }
        public virtual Order Order { get; set; }
    }
}
