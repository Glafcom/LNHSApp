using AutoMapper;
using LNHSApp.Areas.Admin.Models.UsersViewModels;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Filters;
using LNHSApp.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        protected readonly IAdminDomain _adminDomain;

        public UsersController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        } 

        // GET: Admin/Users
        public ActionResult Index(UserFilter filter)
        {
            ViewBag.UserRolesList = EnumHelper.GetEnumDictionary<UserRoles>().Select(ur => new SelectListItem { Value = ur.Key.ToString(), Text = ur.Value });
            var model = new UsersViewModel
            {
                Filter = filter,
                UsersList = _adminDomain.GetUserByFilter(filter).Select(u => Mapper.Map<UserViewModel>(u))
            };
            return View(model);
        }

        [HttpPost]
        public void BlockUser(Guid userId)
        {
            _adminDomain.BlockUser(userId);
        }

        [HttpPost]
        public void UnblockUser(Guid userId)
        {
            _adminDomain.UnblockUser(userId);
        }

        [HttpPost]
        public void DeleteUser(Guid userId)
        {
            _adminDomain.DeleteUser(userId);
        }

        [HttpPost]
        public void GrantPermission(Guid userId, UserRoles userRole)
        {
            _adminDomain.GrantPermissions(userId, userRole);
        }

        [HttpPost]
        public void RemovePermissions(Guid userId, UserRoles userRole)
        {
            _adminDomain.RemovePermissions(userId, userRole);
        }

    }
}