using System;
using System.Collections.Generic;

namespace Gradnik_Data.Models
{
    public class Izlaz
    {
        public int Id { get; set; }
        public string BrojFakture { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int? ProjektId { get; set; }
        public virtual Projekti Projekt { get; set; }
        public virtual Skladiste Skladiste { get; set; }
        public int SkladisteId { get; set; }
        public List<IzlazStavke> IzlazStavke { get; set; }
    }
}