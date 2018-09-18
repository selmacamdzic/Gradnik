using System;
using System.Collections.Generic;

namespace Gradnik_Data.Models
{
    public class Izlaz
    {
        public int Id { get; set; }
        public string BrojFakture { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public virtual Skladiste Skladiste { get; set; }
        public int SkladisteId { get; set; }
        public List<IzlazStavke> IzlazStavke { get; set; }
        public virtual Gradiliste Gradiliste { get; set; }
        public int GradilisteId { get; set; }
    }
}