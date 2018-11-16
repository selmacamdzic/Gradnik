using System;
using System.Collections.Generic;
using System.Linq;

namespace Gradnik_Api.Models
{
    public class ProjektiPrikazVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public string DatumUgovora { get; set; }
        public string PocetakProjekta { get; set; }
        public string KrajProjekta { get; set; }
        public bool Status { get; set; }
        public int KorisnikId { get; set; }
        public string Opis { get; set; }
    }
}