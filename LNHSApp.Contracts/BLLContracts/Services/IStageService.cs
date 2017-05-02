using LNHSApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Contracts.BLLContracts.Services
{
    public interface IStageService : IBaseService<Stage>
    {
        PlayoffStage GetPlayoffStageByGeneralStage(Guid stageId);
        void CreatePlayoffStage(PlayoffStage playoffStage);
        RoundRobinStage GetRRStageByGeneralStage(Guid stageId);
        void CreateRoundRobinStage(RoundRobinStage roundRobinStage);

        void DeleteStagesOfGeneralStage(Guid stageId);
        void DeletePlayoffStageOfGeneralStage(Guid stageId);
        void DeleteRoundRodinStageOfGeneralStage(Guid stageId);
    }
}
