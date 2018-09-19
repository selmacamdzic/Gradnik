using Gradnik_Api.Models;
using Gradnik_Data;
using Gradnik_Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Gradnik_Api.Controllers
{
    public class RadniciController : ApiController
    {
        MojContext ctx = new MojContext();

        [HttpGet]
        [ResponseType(typeof(PrikazRadnikaVM))]
        public PrikazRadnikaVM PrikazZaduženih(int gradilišteId, int tipPoslaId)
        {
            var model = new PrikazRadnikaVM
            {
                listaRadnik = BindRadnici(),
                GradilisteId = gradilisteId,
                TipPoslaId = tipPoslaId
            };

            return Ok(model);
        }


        private List<PrikazRadnikaRow> BindRadnici()
        {
            return ctx.RaspodjelaPosla
                .Where(x => x.GradilisteId == 1 && x.TipPoslaId == 1).Select(x => new PrikazRadnikaRow
                {
                    radnikId = x.Radnik.Id,
                    tipPoslaId = x.TipPoslaId,
                    gradilisteId = x.GradilisteId,
                    imePrezime = x.Radnik.Ime + " " + x.Radnik.Prezime,
                    JMBG = x.Radnik.JMBG,
                    DatumRodjenja = x.Radnik.DatumRodjenja,
                    KontaktTelefon = x.Radnik.KontaktTelefon,
                    Email = x.Radnik.Email,
                    Grad = x.Radnik.Grad,
                    Zvanje = x.Radnik.Zvanje

                }
                )
                .ToList();
        }


        [HttpGet]
        [ResponseType(typeof(List<Radnici>))]
        [Route("api/Radnici/All")]
        public List<Radnici> All()
        {
            var model = ctx.Radnici.ToList();

            return Ok(projekti);
        }


        [HttpGet]
        [ResponseType(typeof(List<RadniciEvidencijaVM>))]
        [Route("api/Radnici/Evidencija/{gradilisteId}/{tipPoslaId}")]
        public List<RadniciEvidencijaVM>  Evidencija(int gradilisteId,int tipPoslaId)
        {
            List<RadniciEvidencijaVM> result = new List<RadniciEvidencijaVM>();
            List<RaspodjelaPosla> raspodjelaPosla = ctx.RaspodjelaPosla.Where(y =>  y.TipPoslaId == obj.TipPoslaId && y.GradilisteId == obj.GradilisteId).ToList();

            foreach (RaspodjelaPosla item in raspodjelaPosla)
            {
                RadniciEvidencijaVM evidencijaVM = new RadniciEvidencijaVM();
                evidencijaVM.RaspodjelaPoslaId = item.Id;

                PrikazRadnikaRow row = new PrikazRadnikaRow();
                row.gradilisteId = item.Gradiliste.Id;
                row.radnikId = item.Radnik.Id;
                row.tipPoslaId = item.TipPosla.Id;
                row.imePrezime = item.Radnik.Ime + " " + item.Radnik.Prezime;
                row.Grad = item.Radnik.Grad;
                row.JMBG = item.Radnik.JMBG;
                row.KontaktTelefon = item.Radnik.KontaktTelefon;
                row.tipPosla = item.TipPosla.Naziv;
                row.isZaduzen = item.KrajRada == null ? true : false;

                evidencijaVM.radnik = row;

                result.Add(evidencijaVM);

            }


            return Ok(result);
        }

    }
}
