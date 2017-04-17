using AutoMapper;
using LNHSApp.Areas.Player.Models.TournamentsViewModels;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Areas.Player.Controllers
{
    public class TournamentsController : Controller
    {
        protected readonly IPlayerDomain _playerDomain;

        public TournamentsController(IPlayerDomain playerDomain)
        {
            _playerDomain = playerDomain;
        }

        // GET: Player/Tournaments
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public void SubscribeToTournament(Guid tournamentId)
        {
            _playerDomain.SubscribeToTournament(tournamentId);
        }

        [HttpPost]
        public void UnsubscribeToTournament(Guid tournamentId)
        {
            _playerDomain.UnsubscribeFromTournament(tournamentId);
        }
    }
}