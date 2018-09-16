using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulEngineering
{
    public class ModulEngineeringAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulEngineering";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulEngineering_default",
                "ModulEngineering/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}