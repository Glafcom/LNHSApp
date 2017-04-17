using System.Web.Mvc;

namespace LNHSApp.Areas.TournamentAdmin
{
    public class TournamentAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TournamentAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TournamentAdmin_default",
                "TournamentAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}