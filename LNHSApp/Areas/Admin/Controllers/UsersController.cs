using LNHSApp.BLLContracts.Interfaces.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        protected readonly IAdminDomain _adminDomain;

        public UsersController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        } 

        // GET: Admin/Users
        public ActionResult Index()
        {
            return View();
        }
    }
}