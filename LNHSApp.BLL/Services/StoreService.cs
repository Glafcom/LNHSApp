using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Contracts.DALContracts;
using LNHSApp.Domain.Filters;
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

        public IEnumerable<Store> GetStoresByFilter(DetailFilter filter)
        {
            var stores = GetItems();

            if (!string.IsNullOrEmpty(filter.Code))
                stores = stores.Where(s => s.Detail != null && s.Detail.Code.Contains(filter.Code));

            if (!string.IsNullOrEmpty(filter.Name))
                stores = stores.Where(s => s.Detail != null && s.Detail.Name.Contains(filter.Name));

            return stores;
        }
    }
}
