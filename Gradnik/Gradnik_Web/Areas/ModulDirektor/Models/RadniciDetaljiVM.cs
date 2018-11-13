using Gradnik_Data.Models;
using System;
using System.Collections.Generic;

namespace Gradnik_Web.Areas.ModulDirektor.Models
{
    public class RadniciDetaljiVM
    {
        public Radnici Radnik { get; set; }
        public RadniciProjektiVM TrenutniProjekat { get; set; }
        public List<RadniciProjektiVM> ZavrseniProjekti { get; set; }
    }

    public class RadniciProjektiVM
    {
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public int ProjektId { get; set; }
    }
}