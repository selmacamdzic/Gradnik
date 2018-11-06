using Gradnik_Api.Models;
using Gradnik_Data;
using System.Linq;
using System.Web.Http;

namespace Gradnik_Api.Controllers
{
    public class RadniciController : ApiController
    {
        MojContext ctx = new MojContext();

        public IHttpActionResult GetRadnici()
        {
            var radnici = ctx.Radnici.ToList();

            return Ok(radnici);
        }

        [HttpPost]
        public IHttpActionResult Login(UserLoginVM obj)
        {
            var korisnik = ctx.Korisnici.FirstOrDefault(r => r.Email == obj.Email && r.Lozinka == obj.Password);

            if (korisnik == null)
            {
                return NotFound();
            }
            return Ok(korisnik);
        }
    }
}
