using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Admin.Models.BreakingsViewModels
{
    public class BreakingViewModel
    {
        public Guid Id { get; set; }
        public bool? IsResolved { get; set; }
        public string Description { get; set; }

        public BreakingDetailViewModel Detail { get; set; }
        public BreakingGameViewModel Game { get; set; }
        public BreakingHockeyTableViewModel HockeyTable { get; set; }
        public IEnumerable<BreakingGuiltyViewModel> Guilties { get; set; }
    }

    public class BreakingDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class BreakingGameViewModel
    {
        public Guid Id { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string TournamentName { get; set; }
        public string StageName { get; set; }
        public int Round { get; set; }
        public BreakingGamePlayerViewModel HomePlayer { get; set; }
        public BreakingGamePlayerViewModel GuestPlayer { get; set; }
    }

    public class BreakingHockeyTableViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }

    public class BreakingGuiltyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class BreakingGamePlayerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}