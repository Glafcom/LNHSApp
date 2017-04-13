using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Contracts.DALContracts;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IGenericRepository<Order> itemRepository)
            : base(itemRepository)
        {

        }
    }
}
