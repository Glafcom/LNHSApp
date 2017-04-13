using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using LNHSApp.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Domains
{
    public class AdminDomain : IAdminDomain
    {
        protected readonly IUserService _userService;
        protected readonly IDetailService _detailService;
        protected readonly IBreakingService _breakingService;
        protected readonly IHockeyTableService _hockeyTableService;

        public AdminDomain(IUserService userService, 
            IDetailService detailService, 
            IBreakingService breakingService,
            IHockeyTableService hockeyTableService)
        {
            _userService = userService;
            _detailService = detailService;
            _breakingService = breakingService;
            _hockeyTableService = hockeyTableService;
        }

        #region Users methods

        public IEnumerable<User> GetUsers()
        {
            return _userService.GetItems();
        }

        public IEnumerable<User> GetUserByFilter(UserFilter filter)
        {
            return _userService.GetUsersByFilter(filter);
        }

        public void BlockUser(Guid userId)
        {
            _userService.BlockUser(userId);
        }

        public void UnblockUser(Guid userId)
        {
            _userService.UnblockUser(userId);
        }

        public void DeleteUser(Guid userId)
        {
            _userService.DeleteItem(userId);
        }

        public void GrantPermissions(Guid userId, UserRoles userRole)
        {
            _userService.SetRoleToUser(userId, userRole.ToString());
        }

        public void RemovePermissions(Guid userId, UserRoles userRole)
        {
            _userService.RemoveRoleFromUser(userId, userRole.ToString());
        }

        #endregion

        #region Store methods



        public IEnumerable<Detail> GetDetails()
        {
            return _detailService.GetItems();
        }

        public IEnumerable<Detail> GetDetailsByFilter(DetailFilter filter)
        {
            return _detailService.GetDetailsByFilter(filter);
        }
        
        public Detail GetDetail(Guid detailId)
        {
            return _detailService.GetItem(detailId);
        }

        public void AddDetail(Detail detail)
        {
            _detailService.AddItem(detail);
        }

        public void ChangeDetail(Detail detail)
        {
            _detailService.ChangeItem(detail.Id, detail);
        }

        public void DeleteDetail(Guid detailId)
        {
            _detailService.DeleteItem(detailId);
        }


        #endregion

        #region Breakings methods

        public IEnumerable<Breaking> GetBreakings()
        {
            return _breakingService.GetItems();
        }

        public IEnumerable<Breaking> GetBreakingsbyFilter(BreakingFilter filter)
        {
            return _breakingService.GetBreakingsByFilter(filter);
        }

        public Breaking GetBreaking(Guid breakingId)
        {
            return _breakingService.GetItem(breakingId);
        }
        public void CreateBreaking(Breaking breaking)
        {
            _breakingService.AddItem(breaking);
        }

        public void EditBreaking(Breaking breaking)
        {
            _breakingService.ChangeItem(breaking.Id, breaking);
        }

        public void DeleteBreaking(Guid breakingId)
        {
            _breakingService.DeleteItem(breakingId);
        }
        public void ResolveBreaking(Guid breakingId, Order outcomeOrder)
        {
            _breakingService.ResolveBreaking(breakingId, outcomeOrder);
        }

        #endregion

        #region Hockey tables methods

        public IEnumerable<HockeyTable> GetHockeyTables()
        {
            return _hockeyTableService.GetItems();
        }

        public IEnumerable<HockeyTable> GetHockeyTablesByFilter(HockeyTableFilter filter)
        {
            return _hockeyTableService.GetHockeyTablesByFilter(filter);
        }

        public HockeyTable GetHockeyTable(Guid hockeyTableId)
        {
            return _hockeyTableService.GetItem(hockeyTableId);
        }

        public void AddHockeyTable(HockeyTable hockeyTable)
        {
            _hockeyTableService.AddItem(hockeyTable);
        }

        public void ChangeHockeyTable(HockeyTable hockeyTable)
        {
            _hockeyTableService.ChangeItem(hockeyTable.Id, hockeyTable);
        }

        public void DeleteHockeyTable(Guid hockeyTableId)
        {
            _hockeyTableService.DeleteItem(hockeyTableId);
        }


        #endregion
    }
}
