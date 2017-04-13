using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.TablesViewModels
{
    public class HockeyTableViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public TableCondition Condition { get; set; }
        public HockeyTableOwnerViewModel Owner { get; set; }
    }

    public class HockeyTableOwnerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}