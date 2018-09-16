using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class FazePrikaz2VM
    {
        public List<SelectListItem> listaFaza { get; set; }
        public int fazaId { get; set; }
        public int statickiProracunId { get; set; }
        public List<SelectListItem> listaMaterijala { get; set; }
        public int materijalId { get; set; }
        public int kolicina { get; set; }
    }
}