using LNHSApp.BLLContracts.Interfaces.Services;
using LNHSApp.DALContracts.Interfaces;
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

        public UserService(IGenericRepository<User> itemRepository)
            : base(itemRepository)
        {

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

        private void ChangeUserStatus(Guid userId, bool isBlocked)
        {
            var user = _itemRepository.GetByID(userId);
            user.IsBlocked = isBlocked;
            ChangeItem(userId, user);
        }

    }
}
