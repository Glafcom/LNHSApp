﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.StagesViewModels
{
    public class CreateRoundRobinStageViewModel
    {
        public int RoundsCount { get; set; }
        public int WinPoints { get; set; }
        public int TiePoints { get; set; }
        public int LosePoints { get; set; }
        public bool HasOvertimes { get; set; }
        public int? OvertimeWinPoints { get; set; }
        public int? OvertimeLosePoints { get; set; }
    }
}