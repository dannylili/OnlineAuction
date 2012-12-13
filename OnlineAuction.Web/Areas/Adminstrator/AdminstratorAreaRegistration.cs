using System.Web.Mvc;

namespace OnlineAuction.Web.Areas.Adminstrator
{
    public class AdminstratorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Adminstrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Adminstrator_default",
                "Adminstrator/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
