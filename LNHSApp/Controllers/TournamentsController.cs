using AutoMapper;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Filters;
using LNHSApp.Models.TournamentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Controllers
{
    public class TournamentsController : Controller
    {
        protected readonly IGuestDomain _guestDomain;

        public TournamentsController(IGuestDomain guestDomain)
        {
            _guestDomain = guestDomain;
        }

        // GET: Tournaments
        public ActionResult Index()
        {
            var model = new TournamentsIndexViewModel
            {
                AllTournaments = _guestDomain.GetTournaments()
                    .Take(10)
                    .Select(t => Mapper.Map<BaseTournamentViewModel>(t))
                    .ToList(),
                PastTournaments = _guestDomain.GetPastTournaments()
                    .Take(10)
                    .Select(t => Mapper.Map<BaseTournamentViewModel>(t))
                    .ToList(),
                CurrentTournaments = _guestDomain.GetCurrentTournaments()
                    .Take(10)
                    .Select(t => Mapper.Map<BaseTournamentViewModel>(t))
                    .ToList(),
                UpcomingTournaments = _guestDomain.GetUpcomingTournaments()
                    .Take(10)
                    .Select(t => Mapper.Map<BaseTournamentViewModel>(t))
                    .ToList(),
            };

            return View(model);
        }

        public ActionResult AllTournaments(TournamentFilter filter)
        {
            var model = new TournamentsViewModel
            {
                Filter = filter,
                TournamentsList = _guestDomain.GetTournamentsByFilter(filter)
                    .Select(t => Mapper.Map<BaseTournamentViewModel>(t)).ToList()
            };
                
            return View("~/Views/Tournamennts/Tournaments.cshml", model);
        }

        public ActionResult CurrentTournaments(TournamentFilter filter)
        {            
            var model = new TournamentsViewModel
            {
                Filter = filter,
                TournamentsList = _guestDomain.GetCurrentTournamentsByFilter(filter)
                    .Select(t => Mapper.Map<BaseTournamentViewModel>(t)).ToList()
            };

            return View("~/Views/Tournamennts/Tournaments.cshml", model);
        }

        public ActionResult PastTournaments(TournamentFilter filter)
        {
            var model = new TournamentsViewModel
            {
                Filter = filter,
                TournamentsList = _guestDomain.GetPastTournamentsByFilter(filter)
                    .Select(t => Mapper.Map<BaseTournamentViewModel>(t)).ToList()
            };

            return View("~/Views/Tournamennts/Tournaments.cshml", model);
        }

        public ActionResult UpcomingTournaments(TournamentFilter filter)
        {
            var model = new TournamentsViewModel
            {
                Filter = filter,
                TournamentsList = _guestDomain.GetUpcomingTournamentsByFilter(filter)
                    .Select(t => Mapper.Map<BaseTournamentViewModel>(t)).ToList()
            };

            return View("~/Views/Tournamennts/Tournaments.cshml", model);
        }

        public ActionResult Tournament(Guid tournamentId)
        {
            var tournament = _guestDomain.GetTournament(tournamentId);
            var model = Mapper.Map<TournamentViewModel>(tournament);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

        }

        [HttpPost]
        public ActionResult Create(BlankTournamentViewModel model)
        {

        }

        [HttpGet]
        public ActionResult Edit(Guid tournamentId)
        {

        }

        [HttpPost]
        public ActionResult Edit(BlankTournamentViewModel model)
        {

        }

        [HttpPost]
        public ActionResult Delete(Guid tournamentId)
        {

        }

    }
}