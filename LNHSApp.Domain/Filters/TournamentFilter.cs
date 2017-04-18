using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Domain.Filters
{
    public class TournamentFilter
    {
        public string Name { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public Guid? Serie { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public TournamentType? Type { get; set; } 
    }
}
