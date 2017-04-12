using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLLContracts.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        void BlockUser(Guid userId);
        void UnblockUser(Guid userId);
        bool DeleteUser(Guid userId);
    }
}
