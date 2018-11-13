using Gradnik_Data.Models;
using System.Collections.Generic;

namespace Gradnik_Web.Areas.ModulDirektor.Models
{
    public class ProjekatDetaljiVM
    {
        public List<ProjekatRadniciVM> Radnici { get; set; }
        public Projekti Projekat { get; set; }
    }

    public class ProjekatRadniciVM
    {
        public int RadnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public string Zvanje { get; set; }
        public string TipPosla { get; set; }
    }
}