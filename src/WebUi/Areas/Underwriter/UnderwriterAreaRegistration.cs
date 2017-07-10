using System.Web.Mvc;

namespace EDeviceClaims.WebUi.Areas.Underwriter
{
    public class UnderwriterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Underwriter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Underwriter_default",
                "Underwriter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}