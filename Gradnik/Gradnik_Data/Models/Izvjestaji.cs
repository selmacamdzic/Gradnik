using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradnik_Data.Models
{
  public  class Izvjestaji
    {
        public int Id { get; set; }
        public string Izvjestaj { get; set; }
        public DateTime Datum { get; set; }

        public int GradilisteId { get; set; }
        public virtual Gradiliste Gradiliste { get; set; }
    }
}
