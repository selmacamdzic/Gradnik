using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista
{
    public class ModulSefGradilistaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulSefGradilista";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulSefGradilista_default",
                "ModulSefGradilista/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}