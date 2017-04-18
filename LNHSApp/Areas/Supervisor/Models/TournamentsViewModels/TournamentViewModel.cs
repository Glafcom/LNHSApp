using LNHSApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNHSApp.Areas.Supervisor.Models.TournamentsViewModels
{
    public class TournamentViewModel
    {        
        public ICollection<TournamentPlayerViewModel> Players { get; set; }
        public ICollection<TournamentTeamViewModel> Teams { get; set; }
        public ICollection<TournamentStageViewModel> Stages { get; set; }
        public ICollection<TournamentAdminViewModel> Admins { get; set; }
        public ICollection<TournamentTableViewModel> Tables { get; set; }
    }

    public class TournamentPlayerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int Rating { get; set; }
    }

    public class TournamentTeamViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }

    public class TournamentStageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StageType Type { get; set; }
        public StageStatus Status { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Order { get; set; }
    }

    public class TournamentAdminViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class TournamentTableViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public TableCondition Condition { get; set; }
        public TournamentTableOwnerViewModel Owner { get; set; }
    }

    public class TournamentTableOwnerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}