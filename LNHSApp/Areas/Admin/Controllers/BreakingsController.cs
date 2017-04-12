using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.Admin.Controllers
{
    public class BreakingsController : Controller
    {
        // GET: Admin/Breakings
        public ActionResult Index()
        {
            return View();
        }
    }
}