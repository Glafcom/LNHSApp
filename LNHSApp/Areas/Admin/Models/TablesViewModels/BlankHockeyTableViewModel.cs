using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.TablesViewModels
{
    public class BlankHockeyTableViewModel
    {
        public string Code { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public TableCondition Condition { get; set; }
        public Guid? OwnerId { get; set; } 
    }
}