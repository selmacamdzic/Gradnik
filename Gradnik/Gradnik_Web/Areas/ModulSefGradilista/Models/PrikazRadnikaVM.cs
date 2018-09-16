using Gradnik_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class PrikazRadnikaVM
    {
        public List<PrikazRadnikaRow> listaRadnika { get; set; }
        public int tiposlaId { get; set; }
        public int gradilisteId { get; set; }
        public string s { get; set; }
    }

    public class PrikazRadnikaRow
    {

        public int radnikId { get; set; }
        public int tipPoslaId { get; set; }
        public int gradilisteId { get; set; }
        public string imePrezime { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string KontaktTelefon { get; set; }
        public string Email { get; set; }
        public string Grad { get; set; }
        public string tipPosla { get; set; }
        public string slika { get; set; }
        public Boolean isZaduzen { get; set; }
        public string  Zvanje { get; set; }
    }
}