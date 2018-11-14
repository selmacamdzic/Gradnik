using System;

namespace Gradnik_Web.Models
{
    public class EvidencijaIsplateDto
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public bool IsPlaceno { get; set; }
        public decimal OdradjeniSati { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public int RadnikId { get; set; }
        public string Gradiliste { get; set; }
        public int GradilisteId { get; set; }
    }
}