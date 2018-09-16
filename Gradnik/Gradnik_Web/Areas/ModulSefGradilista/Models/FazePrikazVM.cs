using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class FazePrikazVM
    {
        public List<FazePrikazRowVM> listaFaza { get; set; }
    }

    public class FazePrikazRowVM
    {
        public int FazaId { get; set; }
        public string Naziv { get; set; }
        public int TehnickiOpisId { get; set; }
    }
}