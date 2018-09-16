using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class EvidencijaVM
    {
        public int TipPoslaId { get; set; }
        public int GradilisteId { get; set; }
        public DateTime DatumRada { get; set; }
        public List<RadnikRadniSatiVM> Radnici { get; set; }
    }

    public class RadnikRadniSatiVM
    {
        public int RadnikId { get; set; }
        public int RadniSati { get; set; }

    }
}