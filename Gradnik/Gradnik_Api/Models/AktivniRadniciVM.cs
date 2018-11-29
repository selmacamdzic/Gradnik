using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Api.Models
{
    public class AktivniRadniciVM
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Zvanje { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; }
        public string KontaktTelefon { get; set; }
        public string Adresa { get; set; }
        public decimal RadniSati { get; set; }
        public int ProjekatId { get; set; }
        public int TipPoslaId { get; set; }
    }
}