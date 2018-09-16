using Gradnik_Data;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Controllers
{
    public class TipPoslaController : Controller
    {
        // GET: ModulSefGradilista/TipPosla

        MojContext ctx = new MojContext();
        public ActionResult TipPoslaByGradiliste(int? id, int? gradilisteId)
        {
            return null;
        }
    }
}