using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulReferent.Models
{
    public class UlaznaFakturaDodajVM
    {
        [Required]
        public string BrojFakture { get; set; }
        [Required]
        public decimal Iznos { get; set; }
        [Required]
        public string Valuta { get; set; }

        [Required]
        public int NarudzbaMaterijalaId { get; set; }
        public List<SelectListItem> listaNarudzbaMaterijala;

        [Required]
        public int DobavljaciId { get; set; }
        public List<SelectListItem> listaDobavljaca;
    }
}