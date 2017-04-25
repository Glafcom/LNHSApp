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
    }
}