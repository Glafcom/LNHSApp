﻿using LNHSApp.Contracts.BLLContracts.Services;
using LNHSApp.Contracts.DALContracts;
using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.BLL.Services
{
    public class StageService : BaseService<Stage>, IStageService
    {
        protected IPlayoffStageService _playoffStageService;
        protected IRoundRobinStageService _roundRobinStageService;
                
        public StageService(IGenericRepository<Stage> itemRepository,
            IPlayoffStageService playoffStageService,
            IRoundRobinStageService roundRobinStageService)
            : base(itemRepository)
        {
            _playoffStageService = playoffStageService;
            _roundRobinStageService = roundRobinStageService;
        }

        public PlayoffStage GetPlayoffStageByGeneralStage(Guid stageId)
        {
            return _playoffStageService.GetItems().Where(pos => pos.StageId == stageId).FirstOrDefault();
        }

        public void CreatePlayoffStage(PlayoffStage playoffStage)
        {
            _playoffStageService.AddItem(playoffStage);
        }

        public RoundRobinStage GetRRStageByGeneralStage(Guid stageId)
        {
            return _roundRobinStageService.GetItems().Where(rrs => rrs.StageId == stageId).FirstOrDefault();
        }

        public void CreateRoundRobinStage(RoundRobinStage roundRobinStage)
        {
            _roundRobinStageService.AddItem(roundRobinStage);
        }

        public void DeleteStagesOfGeneralStage(Guid stageId)
        {
            DeletePlayoffStageOfGeneralStage(stageId);
            DeleteRoundRodinStageOfGeneralStage(stageId);
        }

        public void DeletePlayoffStageOfGeneralStage(Guid stageId)
        {
            var playoffStage = GetPlayoffStageByGeneralStage(stageId);
            if (playoffStage != null)
                _playoffStageService.DeleteItem(playoffStage.Id);
        }

        public void DeleteRoundRodinStageOfGeneralStage(Guid stageId)
        {
            var roundRobinStage = GetRRStageByGeneralStage(stageId);
            if (roundRobinStage != null)
                _roundRobinStageService.DeleteItem(roundRobinStage.Id);
        }
    }
}
