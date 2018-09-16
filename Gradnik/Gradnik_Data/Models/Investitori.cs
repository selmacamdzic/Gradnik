using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradnik_Data.Models
{
   public class Investitori
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string ImeOdgovorneOsobe { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
    }
}
