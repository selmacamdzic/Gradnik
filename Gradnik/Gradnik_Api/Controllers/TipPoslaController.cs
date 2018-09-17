using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gradnik_Api.Controllers
{
    public class TipPoslaController : ApiController
    {
        MojContext ctx = new MojContext();

        [HttpGet]
        [Route("api/TipPosla/{id")]
        [ResponseType(typeof(List<Projekti>))]
        public List<Projekti> Aktivni(int id)
        {
            Gradiliste gradiliste = new Gradiliste();

            if (id != null)
            {
                gradiliste = ctx.Gradiliste.Where(x => x.ProjektiId == id).Single();

            }
            else
            {
                gradiliste = ctx.Gradiliste.Find(gradilisteId);
            }

            var model = new TipPoslaVM();
            model.GradilisteId = gradiliste.Id;

            List<TipPoslaRowVM> tipPoslaIds = ctx.TipPosla.Select(x => new TipPoslaRowVM { TipPoslaId = x.Id, TipPoslaNaziv = x.Naziv }).ToList();
            foreach (TipPoslaRowVM item in tipPoslaIds)
            {
                item.count = CountTipPosla(gradiliste.Id, item.TipPoslaId);
            }

            model.listTipPosla = tipPoslaIds;

            return Ok(projekti);

        }

    }
}
