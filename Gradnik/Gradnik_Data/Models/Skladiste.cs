using System.Collections.Generic;

namespace Gradnik_Data.Models
{
    public class Skladiste
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public List<Ulaz> Ulaz { get; set; }
        public List<Izlaz> Izlaz { get; set; }
    }
}
