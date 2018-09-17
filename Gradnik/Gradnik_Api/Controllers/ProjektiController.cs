using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gradnik_Api.Controllers
{
    public class ProjektiController : ApiController
    {
        MojContext ctx = new MojContext();

        [HttpGet]
        [Route("api/Projekti/Aktivni/{id}")]
        [ResponseType(typeof(List<Projekti>))]
        public List<Projekti> Aktivni(int id)
        {

            List<Projekti> projekti = ctx.Projekti
                .Where(x => x.Status == ProjektStatus.Aktivan)
                .ToList();

            return Ok(projekti);

        }


        [HttpGet]
        [ResponseType(typeof(List<Projekti>))]
        public List<Projekti> Index()
        {

            List<Projekti> projekti = ctx.Projekti
                .ToList();

            return Ok(projekti);

        }

    }
}
