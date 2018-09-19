using Gradnik_Api.Models;
using Gradnik_Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Gradnik_Api.Controllers
{
    public class IzvjestajController : ApiController
    {
        MojContext ctx = new MojContext();

        [HttpGet]
        [ResponseType(typeof(List<IzvjestajVM>))]
        [Route("api/Izvjestaj/Prikaz/{gradilisteId}/{tipPoslaId}")]
        public List<IzvjestajVM> Prikaz(int projekatId)
        {
            int gradilisteId = ctx.Gradiliste.Where(x => x.ProjektiId == 1).FirstOrDefault().Id;
           List< IzvjestajVM> result = ctx.Izvjestaji.Where(x => x.GradilisteId == gradilisteId).Select(x => new IzvjestajVM
            { Izvjestaj=x.Izvjestaj,
                Datum=x.Datum
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult Spremi(Izvjestaj vm)
        {
            ctx.Sati.Add(vm);
            ctx.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }
    }
}
