using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulDirektor
{
    public class ModulDirektorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulDirektor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulDirektor_default",
                "ModulDirektor/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}