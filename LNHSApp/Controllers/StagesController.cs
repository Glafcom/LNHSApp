using AutoMapper;
using LNHSApp.Contracts.BLLContracts.Domains;
using LNHSApp.Domain.Enums;
using LNHSApp.Domain.Models;
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
                var playoffStage = _playerDomain.GetPlayoffStage(stageId);
                return View

            }
            else
            {

            }
            
        }

        public ActionResult PlayoffStage(Guid stageId)
        {

        }

        public ActionResult RoundRobinStage(Guid stageId)
        {

        }

        

        [HttpGet]
        public ActionResult Create()
        {
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
            return View(new CreateRoundRobinStageViewModel());
        }

        [HttpPost]
        public ActionResult CreatePlayoffStage(CreateRoundRobinStageViewModel model)
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

        [HttpPost]
        public ActionResult Edit(EditStageViewModel model)
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
        public ActionResult EditPlayoffStage(Guid stageId)
        {
            var playoffStage = _supervisorDomain.GetPlayoffStage(stageId);

        }

        [HttpPost]
        public ActionResult EditPlayoffStage(EditPlayoffStageViewModel model)
        {
            

        }

        [HttpGet]
        public ActionResult EditRoundRobinStage(Guid stageId)
        {
            var roundRobinStage = _supervisorDomain.GetRoundRobinStage(stageId);

        }

        [HttpPost]
        public ActionResult EditRoundRobinStage(EditRoundRobinStageViewModel model)
        {
            

        }
    }
}