using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulEngineering.Models
{
    public class ProjektnaDokumentacijaAddVM
    {
        public int projekatId { get; set; }
        public string Opis { get; set; }
        public HttpPostedFileBase CrtezPresjek { get; set; }
        public HttpPostedFileBase CrtezOsnova { get; set; }
        public HttpPostedFileBase CrtezKrov { get; set; }
        public HttpPostedFileBase CrtezFasada { get; set; }

    }
}