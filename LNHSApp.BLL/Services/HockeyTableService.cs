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
    public class HockeyTableService : BaseService<HockeyTable>, IHockeyTableService
    {
        public HockeyTableService(IGenericRepository<HockeyTable> itemRepository)
            : base(itemRepository)
        {
        }

        public IEnumerable<HockeyTable> GetHockeyTablesByFilter(HockeyTableFilter filter)
        {
            var hockeyTables = GetItems();

            if (!string.IsNullOrEmpty(filter.Code))
                hockeyTables = hockeyTables.Where(ht => ht.Code.Contains(filter.Code));

            if (!string.IsNullOrEmpty(filter.Model))
                hockeyTables = hockeyTables.Where(ht => ht.Model.Contains(filter.Model));

            if (!string.IsNullOrEmpty(filter.OwnerName))
                hockeyTables = hockeyTables.Where(ht => ht.Owner != null && ht.Owner.Name.Contains(filter.OwnerName));

            if (!string.IsNullOrEmpty(filter.OwnerSurname))
                hockeyTables = hockeyTables.Where(ht => ht.Owner != null && ht.Owner.Surname.Contains(filter.OwnerSurname));

            if (filter.Condition != null)
                hockeyTables = hockeyTables.Where(ht => ht.Condition == filter.Condition);

            return hockeyTables;
        }
    }
}
