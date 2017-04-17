using AutoMapper;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Filters;
using LNHSApp.Models.TeamsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Controllers
{
    public class TeamsController : Controller
    {
        protected readonly IGuestDomain _guestDomain;

        public TeamsController(IGuestDomain guestDomain)
        {
            _guestDomain = guestDomain;
        }

        // GET: Teams
        public ActionResult Index(TeamFilter filter)
        {
            var model = new TeamsViewModel
            {
                Filter = filter,
                TeamsList = _guestDomain.GetTeamsByFilter(filter)
                    .Select(t => Mapper.Map<TeamViewModel>(t))
                    .ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Team(Guid teamId)
        {
            var team = _guestDomain.GetTeam(teamId);
            var model = Mapper.Map<TeamViewModel>(team);
            return View(model);
        }
    }
}