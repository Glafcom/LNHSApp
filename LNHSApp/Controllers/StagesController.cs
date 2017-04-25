using AutoMapper;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Models;
using LNHSApp.Extensions.Helpers;
using LNHSApp.Models.StagesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNHSApp.Controllers
{
    public class StagesController : Controller
    {
        protected ISupervisorDomain _supervisorDomain;
        protected IPlayerDomain _playerDomain;

        public StagesController(ISupervisorDomain supervisorDomain, IPlayerDomain playerDomain)
        {
            _supervisorDomain = supervisorDomain;
            _playerDomain = playerDomain;
        }

        public ActionResult Detail(Guid stageId)
        {
            var stage = _playerDomain.GetStage(stageId);
            if (stage.Type == StageType.Playoff)
            {   
                return RedirectToAction("PlayoffStage", new { stageId = stageId });
            }
            else
            {
                return RedirectToAction("RoundRobinStage", new { stageId = stageId });
            }
            
        }

        public ActionResult PlayoffStage(Guid stageId)
        {
            var playoffStage = _playerDomain.GetPlayoffStage(stageId);
            var model = Mapper.Map<PlayoffStageViewModel>(playoffStage);
            return View(model);
        }

        public ActionResult RoundRobinStage(Guid stageId)
        {
            var roundRobinStage = _playerDomain.GetRoundRobinStage(stageId);
            var model = Mapper.Map<RoundRobinStageViewModel>(roundRobinStage);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TypesList = EnumHelper.GetEnumDictionary<StageType>()
                .Select(st => new SelectListItem { Value = st.Key.ToString(), Text = st.Value });
            return View(new CreateStageViewModel());
        }

        [HttpPost]
        public ActionResult Create(CreateStageViewModel model)
        {
            TempData["StageModel"] = model;

            if (model.Type == StageType.Playoff)
            {
                return RedirectToAction("CreatePlayoffStage");
            }
            else
            {
                return RedirectToAction("CreateRoundRobinStage");
            }
        }

        [HttpGet]
        public ActionResult CreatePlayoffStage()
        {
            return View(new CreatePlayoffStageViewModel());
        }

        [HttpPost]
        public ActionResult CreatePlayoffStage(CreatePlayoffStageViewModel model)
        {
            if (TempData["StageModel"] != null)
            {
                var stageModel = TempData["StageModel"] as CreateStageViewModel;
                var stage = _supervisorDomain.CreateStage(Mapper.Map<Stage>(stageModel));
                var playoffStage = Mapper.Map<PlayoffStage>(model);
                playoffStage.StageId = stage.Id;
                _supervisorDomain.CreatePlayoffStage(playoffStage);
                return RedirectToAction("Detail", new { stageId = stage.Id });
            }
            else
            {
                return View("error");
            }
            
        }

        [HttpGet]
        public ActionResult CreateRoundRobinStage()
        {
            ViewBag.RoundsList = EnumHelper.GetIntArray(1, 5)
                .Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            ViewBag.PointsList = EnumHelper.GetIntArray(1, 7)
                .Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString()});

            return View(new CreateRoundRobinStageViewModel());
        }

        [HttpPost]
        public ActionResult CreateRoundRobinStage(CreateRoundRobinStageViewModel model)
        {
            if (TempData["StageModel"] != null)
            {
                var stageModel = TempData["StageModel"] as CreateStageViewModel;
                var stage = _supervisorDomain.CreateStage(Mapper.Map<Stage>(stageModel));
                var roundRobinStage = Mapper.Map<RoundRobinStage>(model);
                roundRobinStage.StageId = stage.Id;
                _supervisorDomain.CreateRoundRobinStage(roundRobinStage);
                return RedirectToAction("Detail", new { stageId = stage.Id });
            }
            else
            {
                return View("error");
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid stageId)
        {
            EditStageViewModel model;
            var stage = _supervisorDomain.GetStage(stageId);

            if (stage.Type == StageType.Playoff)
            {
                var playoffStage = _supervisorDomain.GetPlayoffStageByGeneralStage(stageId);
                model = Mapper.Map<EditStageViewModel>(playoffStage);
            }
            else
            {
                var roundRobinStage = _supervisorDomain.GetRoundRobinStageByGeneralStage(stageId);
                model = Mapper.Map<EditStageViewModel>(roundRobinStage);
            }
            
            ViewBag.TypesList = EnumHelper.GetEnumDictionary<StageType>()
                .Select(st => new SelectListItem { Value = st.Key.ToString(), Text = st.Value });
            ViewBag.RoundsList = EnumHelper.GetIntArray(1, 5)
                .Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            ViewBag.PointsList = EnumHelper.GetIntArray(1, 7)
                .Select(i => new SelectListItem { Value = i.ToString(), Text = i.ToString() });

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditStageViewModel model)
        {
            var stage = Mapper.Map<>

            return RedirectToAction("Detail", new { stageId = stage.Id });
        }

        
    }
}