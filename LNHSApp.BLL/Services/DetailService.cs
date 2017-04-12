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
    public class DetailService : BaseService<Detail>, IDetailService
    {
        public DetailService(IGenericRepository<Detail> itemRepository)
            : base(itemRepository)
        {
        }

        public IEnumerable<Detail> GetDetailsByFilter(DetailFilter filter)
        {
            var details = GetItems();

            if (!string.IsNullOrEmpty(filter.Code))
                details = details.Where(d => d.Code.Contains(filter.Code));

            if (!string.IsNullOrEmpty(filter.Name))
                details = details.Where(d => d.Name.Contains(filter.Name));

            return details;
        }
    }
}
