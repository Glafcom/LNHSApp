using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Models
{
    public class Order : BaseModel
    {
        public Order()
        {
            this.Items = new HashSet<OrderItem>();
            this.ResolvedBreakings = new HashSet<Breaking>();
        }

        public string Number { get; set; }
        public DateTime Date { get; set; }
        public Guid BaileeId { get; set; }
        public OrderType Type { get; set; }

        public virtual User Bailee { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
        public virtual ICollection<Breaking> ResolvedBreakings { get; set; }
    }
}
