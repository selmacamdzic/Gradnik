using System;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class RapsodjelaRadnikaPrikazVM
    {
        public int RadnikId { get; set; }
        public int RaspodjelaId { get; set; }
        public DateTime PocetakRada { get; set; }
        public string Opis { get; set; }
        public string Gradiliste { get; set; }
        public string TipPosla { get; set; }
    }
}