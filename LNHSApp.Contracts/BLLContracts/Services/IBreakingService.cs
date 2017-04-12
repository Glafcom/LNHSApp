using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Services
{
    public interface IBreakingService : IBaseService<Breaking>
    {
        IEnumerable<Breaking> GetBreakingsByFilter(BreakingFilter filter);
    }
}
