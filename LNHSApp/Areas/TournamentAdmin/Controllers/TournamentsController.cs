using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.TournamentAdmin.Controllers
{
    public class TournamentsController : Controller
    {
        // GET: TournamentAdmin/Tournaments
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            
        }

        [HttpPost]
        public ActionResult Create()
        {

        }
    }
}