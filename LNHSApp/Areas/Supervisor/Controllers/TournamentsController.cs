using AutoMapper;
using LNHSApp.Areas.Supervisor.Models.TournamentsViewModels;
using LNHSApp.Contracts.BLLContracts.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.TournamentAdmin.Controllers
{
    public class TournamentsController : Controller
    {
        protected readonly ISupervisorDomain _supervisorDomain;

        public TournamentsController(ISupervisorDomain supervisorDomain)
        {
            _supervisorDomain = supervisorDomain;
        }

        [HttpGet]
        public ActionResult Index()
        {

        }

        [HttpGet]
        public ActionResult Tournament(Guid tournamentId)
        {
            var tournament = _supervisorDomain.GetTournament(tournamentId);

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