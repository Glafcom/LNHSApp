﻿using AutoMapper;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Filters;
using LNHSApp.Domain.Models;
using LNHSApp.Extensions.Helpers;
using LNHSApp.Models.StagesViewModels;
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
        protected readonly ISupervisorDomain _supervisorDomain;

        public TournamentsController(IGuestDomain guestDomain, ISupervisorDomain supervisorDomain)
        {
            _guestDomain = guestDomain;
            _supervisorDomain = supervisorDomain;
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
            ViewBag.TournamentTypesList = EnumHelper.GetEnumDictionary<TournamentType>().Select(tt => new SelectListItem { Value = tt.Key.ToString(), Text = tt.Value });
            ViewBag.SeriesList = _supervisorDomain.GetSeries().Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            return View(new CreateTournamentViewModel());
        }

        [HttpPost]
        public ActionResult Create(CreateTournamentViewModel model)
        {
            var tournament = _supervisorDomain.CreateTournament(Mapper.Map<Tournament>(model));
            return RedirectToAction("Tournament", new { tournamentId = tournament.Id });
        }

        [HttpGet]
        public ActionResult Edit(Guid tournamentId)
        {
            var tournament = _supervisorDomain.GetTournament(tournamentId);
            var model = Mapper.Map<EditTournamentViewModel>(tournament);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditTournamentViewModel model)
        {
            _supervisorDomain.EditTournament(Mapper.Map<Tournament>(model));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Guid tournamentId)
        {
            _supervisorDomain.DeleteTournament(tournamentId);
            return RedirectToAction("Index");
        }
    }
}