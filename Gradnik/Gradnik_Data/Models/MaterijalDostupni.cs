using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradnik_Data.Models
{
   public class MaterijalDostupni
    {
        public int Id { get; set; }
        public int Utroseno { get; set; }
        public int Preostalo { get; set; }

        public int NarudzbaMaterijalaId { get; set; }

        public int GradilisteId { get; set; }
        public virtual Gradiliste Gradiliste { get; set; }
    }
}
