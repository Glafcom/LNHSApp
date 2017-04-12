using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Services
{
    public interface IDetailService : IBaseService<Detail>
    {
        IEnumerable<Detail> GetDetailsByFilter(DetailFilter filter);
    }
}
