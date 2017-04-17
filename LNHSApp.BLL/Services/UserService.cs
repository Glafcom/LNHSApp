using LNHSApp.BLL.Identity;
using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Contracts.DALContracts;
using LNHSApp.Contracts.DALContracts.Identity;
using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        protected readonly IApplicationUserManager _userManager;
        
        public UserService(IGenericRepository<User> itemRepository, IApplicationUserManager userManager)
            : base(itemRepository)
        {
            _userManager = userManager;
        }

        public IEnumerable<User> GetUsersByFilter(UserFilter filter)
        {
            var users = GetItems();

            if (!string.IsNullOrEmpty(filter.UserName))
                users = users.Where(u => u.UserName.Contains(filter.UserName));

            if (!string.IsNullOrEmpty(filter.Name))
                users = users.Where(u => u.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Surname))
                users = users.Where(u => u.Surname.Contains(filter.Surname));

            if (!string.IsNullOrEmpty(filter.Country))
                users = users.Where(u => u.Country.Contains(filter.Country));

            if (!string.IsNullOrEmpty(filter.City))
                users = users.Where(u => u.City.Contains(filter.City));

            if (filter.MinAge != null)
            {
                var targetDate = DateTime.Now.AddYears(-(int)filter.MinAge);
                users = users.Where(u => u.DayOfBirth <= targetDate);
            }

            if (filter.MaxAge != null)
            {
                var targetDate = DateTime.Now.AddYears(-(int)filter.MaxAge);
                users = users.Where(u => u.DayOfBirth >= targetDate);
            }

            if (filter.State.HasValue)
            {
                if ((UserState)filter.State == UserState.Active)
                    users = users.Where(u => !u.IsBlocked.HasValue || !(bool)u.IsBlocked);
                if ((UserState)filter.State == UserState.Blocked)
                    users = users.Where(u => u.IsBlocked.HasValue && (bool)u.IsBlocked);
            }
                


            return users;
        }

        public async Task SetRoleToUser(Guid userId, string role)
        {
            await _userManager.AddToRoleAsync(userId, role);
        }

        public async Task RemoveRoleFromUser(Guid userId, string role)
        {
            await _userManager.RemoveFromRoleAsync(userId, role);
        }

        public void BlockUser(Guid userId)
        {
            ChangeUserStatus(userId, true);
        }

        public void UnblockUser(Guid userId)
        {
            ChangeUserStatus(userId, false);
        }

        public bool DeleteUser(Guid userId)
        {
            var user = GetItem(userId);

            if (user.IsBlocked != null && (bool)user.IsBlocked)
                return false;

            DeleteItem(userId);

            return true;
        }

        #region Players methods

        public IEnumerable<User> GetPlayers()
        {
            return GetItems().Where(u => _userManager.IsInRoleAsync(u.Id, "Player").Result && (!u.IsBlocked.HasValue || !(bool)u.IsBlocked));
        }

        public IEnumerable<User> GetPlayersByFilter(PlayerFilter filter)
        {
            var players = GetPlayers();
                        
            if (!string.IsNullOrEmpty(filter.Name))
                players = players.Where(p => p.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Surname))
                players = players.Where(p => p.Surname.Contains(filter.Surname));

            if (!string.IsNullOrEmpty(filter.Country))
                players = players.Where(p => p.Country.Contains(filter.Country));

            if (!string.IsNullOrEmpty(filter.City))
                players = players.Where(p => p.City.Contains(filter.City));

            if (filter.MinAge != null)
            {
                var targetDate = DateTime.Now.AddYears(-(int)filter.MinAge);
                players = players.Where(u => u.DayOfBirth <= targetDate);
            }

            if (filter.MaxAge != null)
            {
                var targetDate = DateTime.Now.AddYears(-(int)filter.MaxAge);
                players = players.Where(u => u.DayOfBirth >= targetDate);
            }

            return players;
        }

        public User GetPlayer(Guid playerId)
        {
            return GetPlayers().FirstOrDefault(p => p.Id == playerId);
        }

        #endregion

        private void ChangeUserStatus(Guid userId, bool isBlocked)
        {
            var user = _itemRepository.GetByID(userId);
            user.IsBlocked = isBlocked;
            ChangeItem(userId, user);
        }

    }
}
