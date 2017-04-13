using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.OrdersViewModels
{
    public class BlankOrderViewModel
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public OrderType Type { get; set; }
        public string Note { get; set; }
        public BaileeViewModel Bailee { get; set; }

        public IEnumerable<OrderItemViewModel> Items { get; set; }
    }

    public class BaileeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
        public Guid? DetailId { get; set; }
        public string DetailName { get; set; }
        public string DetailCode { get; set; }
        public int Count { get; set; }
    }
}