using AutoMapper;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Filters;
using LNHSApp.Models.PlayersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Controllers
{
    public class PlayersController : Controller
    {
        protected readonly IGuestDomain _guestDomain;

        public PlayersController(IGuestDomain guestDomain)
        {
            _guestDomain = guestDomain;
        }

        // GET: Players
        public ActionResult Index(PlayerFilter filter)
        {
            var model = new PlayersViewModel
            {
                Filter = filter,
                PlayersList = _guestDomain.GetPlayersByFilter(filter)
                    .Select(p => Mapper.Map<PlayerViewModel>(p))
                    .ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Player(Guid playerId)
        {
            var player = _guestDomain.GetPlayer(playerId);
            var model = Mapper.Map<PlayerViewModel>(player);
            return View(model);
        }
    }
}