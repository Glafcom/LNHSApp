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

        IEnumerable<Store> GetStores();
        IEnumerable<Store> GetStoresByFilter(DetailFilter filter);
        

        IEnumerable<Detail> GetDetails();
        IEnumerable<Detail> GetDetailsByFilter(DetailFilter filter);
        Detail GetDetail(Guid detailId);
        void AddDetail(Detail detail);
        void ChangeDetail(Detail detail);
        void DeleteDetail(Guid detailId);

        IEnumerable<Breaking> GetBreakings();
        IEnumerable<Breaking> GetBreakingsbyFilter(BreakingFilter filter);
        Breaking GetBreaking(Guid breakingId);
        void CreateBreaking(Breaking breaking);
        void EditBreaking(Breaking breaking);
        void DeleteBreaking(Guid breakingId);
        void ResolveBreaking(Guid breakingId, Order outcomeOrder);


        IEnumerable<HockeyTable> GetHockeyTables();
        IEnumerable<HockeyTable> GetHockeyTablesByFilter(HockeyTableFilter filter);
        HockeyTable GetHockeyTable(Guid hockeyTableId);
        void AddHockeyTable(HockeyTable hockeyTable);
        void ChangeHockeyTable(HockeyTable hockeyTable);
        void DeleteHockeyTable(Guid hockeyTableId);
        int GetHockeyTablesCount();
    }
}
