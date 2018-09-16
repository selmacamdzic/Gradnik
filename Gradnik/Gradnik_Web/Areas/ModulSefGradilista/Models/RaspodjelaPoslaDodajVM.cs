using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class RaspodjelaPoslaDodajVM
    {
        public int RadnikId { get; set; }
        public int GradilisteId { get; set; }
        public int TipPoslaId { get; set; }
        public string Opis { get; set; }
        [DataType(DataType.Date)]
        public DateTime PocetakRada { get; set; }
        public List<SelectListItem> listaRadnik;
        public List<SelectListItem> TipPosla;
    }
}