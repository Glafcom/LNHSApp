using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Domains
{
    public interface IAdminDomain
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUserByFilter(UserFilter filter);
        void BlockUser(Guid userId);
        void UnblockUser(Guid userId);
        void DeleteUser(Guid userId);
        void GrantPermissions(Guid userId, UserRoles userRole);
        void RemovePermissions(Guid userId, UserRoles userRole);


        IEnumerable<Detail> GetDetails();
        IEnumerable<Detail> GetDetailsByFilter(DetailFilters filter);
        Detail GetDetail(Guid detailId);
        void AddDetail(Detail detail);
        void ChangeDetail(Detail detail);
        void DeleteDetail(Guid detailId);

    }
}
