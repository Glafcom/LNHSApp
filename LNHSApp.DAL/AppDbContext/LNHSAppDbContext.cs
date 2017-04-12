using LNHSApp.Domain.Models;
using LNHSApp.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.DAL.AppDbContext
{
    public class LNHSAppDbContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public LNHSAppDbContext()
            : base("LNHSAppDbConnection")
        { }

        public DbSet<Breaking> Breakings { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<HockeyTable> HockeyTables { get; set; }
        public DbSet<Jingle> Jingles { get; set; }
        public DbSet<PlayoffStage> PlayoffStages { get; set; }
        public DbSet<RoundRobinStage> RoundRobinStages { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        

        public static LNHSAppDbContext Create()
        {
            return new LNHSAppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
