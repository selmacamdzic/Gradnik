using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Api.Models
{
    public class RaspodjelaPoslaDodajVM
    {
       
        public int GradilisteId { get; set; }
        public int TipPoslaId { get; set; }
        public string Opis { get; set; }
        [DataType(DataType.Date)]
        public DateTime PocetakRada { get; set; }
        public List<RadnikVM> listaRadnik;
        public List<int> radniciId;
    }
}