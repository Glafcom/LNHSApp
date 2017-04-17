using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Services
{
    public interface ITeamService : IBaseService<Team>
    {
        IEnumerable<Team> GetTeamsByFilter(TeamFilter filter);
    }
}
