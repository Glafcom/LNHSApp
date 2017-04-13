using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Filters
{
    public class BreakingFilter
    {
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public Guid? Detail { get; set; }
        public Guid? HockeyTable { get; set; }
        public BreakingState? State { get; set; }
    }
}
