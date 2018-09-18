using System.Collections.Generic;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class AddIzlazVM
    {
        public List<SelectListItem> Materijal { get; set; }
        public List<SelectListItem> Skladiste { get; set; }
        public int Kolicina { get; set; }
        public int MaterijalId { get; set; }
        public int GradilisteId { get; set; }
        public int SkladisteId { get; set; }
    }
}