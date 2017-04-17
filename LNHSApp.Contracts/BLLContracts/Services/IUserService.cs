using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Services
{
    public interface IUserService : IBaseService<User>
    {
        IEnumerable<User> GetUsersByFilter(UserFilter filter);
        Task SetRoleToUser(Guid userId, string role);
        Task RemoveRoleFromUser(Guid userId, string role);
        void BlockUser(Guid userId);
        void UnblockUser(Guid userId);
        bool DeleteUser(Guid userId);

        IEnumerable<User> GetPlayers();
        IEnumerable<User> GetPlayersByFilter(PlayerFilter filter);
        User GetPlayer(Guid playerId);
    }
}
