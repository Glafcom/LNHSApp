using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Models.StagesViewModels
{
    public class CreateStageViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public StageType Type { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}