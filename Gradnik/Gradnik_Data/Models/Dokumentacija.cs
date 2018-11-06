using System;

namespace Gradnik_Data.Models
{
    public class Dokumentacija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public byte[] File { get; set; }
        public Projekti Projekat { get; set; }
        public int ProjekatId { get; set; }
    }
}
