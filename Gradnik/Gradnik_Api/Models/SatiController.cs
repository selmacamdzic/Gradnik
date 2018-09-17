using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gradnik_Api.Models
{
    public class SatiController : ApiController
    {
        MojContext ctx = new MojContext();

        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("api/Sati/Spremi/{RaspodjelaPoslaId}/{sati}")]
        public IHttpActionResult Spremi(int RaspodjelaPoslaId, int sati)
        {
            RaspodjelaPosla raspodjelaPosla = ctx.RaspodjelaPosla.Find(RaspodjelaPoslaId);

            if (raspodjelaPosla != null)
            {
                item.RaspodjelaPoslaId = raspodjelaPosla.Id;
                ctx.Sati.Add(sati);
                ctx.SaveChanges();
            }

            return StatusCode(HttpStatusCode.OK);
        }
    }
}
