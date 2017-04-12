using LNHSApp.BLLContracts.Interfaces.Services;
using LNHSApp.DALContracts.Interfaces;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Services
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        public StoreService(IGenericRepository<Store> itemRepository)
            : base(itemRepository)
        {
        }
    }
}
