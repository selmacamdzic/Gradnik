using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradnik_Data.Models
{
   public class Sati
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public bool isPlaceno { get; set; }
        public decimal OdradjeniSati { get; set; }

        public int RaspodjelaPoslaId { get; set; }
        public virtual RaspodjelaPosla RaspodjelaPosla { get; set; }
    }
}
