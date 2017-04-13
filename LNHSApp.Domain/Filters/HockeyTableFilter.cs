using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Filters
{
    public class HockeyTableFilter
    {
        public string Code { get; set; }
        public string Model { get; set; }
        public TableCondition? Condition { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
    }
}
