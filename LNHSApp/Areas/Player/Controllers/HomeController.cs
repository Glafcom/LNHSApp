using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.Player.Controllers
{
    public class HomeController : Controller
    {
        // GET: Player/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}