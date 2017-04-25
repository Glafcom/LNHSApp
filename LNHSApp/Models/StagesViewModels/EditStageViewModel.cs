using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.StagesViewModels
{
    public class EditStageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public int Order { get; set; }
        public StageStatus Status { get; set; }
        public StageType Type { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        #region Playoff stage properties

        public Guid? PlayoffStageId { get; set; }
        public int? CompetitorsCount { get; set; }
        public string PlayoffFormula { get; set; }
        public bool? HasThirdPlaceGame { get; set; }

        #endregion

        #region Round robin stage properties

        public Guid? RoundRobinStageId { get; set; }
        public int? RoundsCount { get; set; }
        public int? WinPoints { get; set; }
        public int? TiePoints { get; set; }
        public int? LosePoints { get; set; }
        public bool? HasOvertimes { get; set; }
        public int? OvertimeWinPoints { get; set; }
        public int? OvertimeLosePoints { get; set; }

        #endregion

    }
}