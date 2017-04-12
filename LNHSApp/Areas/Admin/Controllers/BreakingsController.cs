using LNHSApp.Contracts.BLLContracts.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.Admin.Controllers
{
    public class BreakingsController : Controller
    {
        protected readonly IAdminDomain _adminDomain;

        public BreakingsController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        }

        // GET: Admin/Breakings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }


    }
}