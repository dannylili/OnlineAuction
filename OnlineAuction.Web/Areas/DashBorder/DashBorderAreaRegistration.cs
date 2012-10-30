using System.Web.Mvc;

namespace OnlineAuction.Web.Areas.DashBorder
{
    public class DashBorderAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DashBorder";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DashBorder_default",
                "DashBorder/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
