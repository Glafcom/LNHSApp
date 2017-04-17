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
    public class TeamService : BaseService<Team>, ITeamService
    {
        public TeamService(IGenericRepository<Team> itemRepository)
            : base(itemRepository)
        {
        }

        public IEnumerable<Team> GetTeamsByFilter(TeamFilter filter)
        {
            var teams = GetItems();

            if (!string.IsNullOrEmpty(filter.Name))
                teams = teams.Where(t => t.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Country))
                teams = teams.Where(t => t.Country.Contains(filter.Country));

            if (!string.IsNullOrEmpty(filter.City))
                teams = teams.Where(t => t.City.Contains(filter.City));

            return teams;
        }
    }
}
