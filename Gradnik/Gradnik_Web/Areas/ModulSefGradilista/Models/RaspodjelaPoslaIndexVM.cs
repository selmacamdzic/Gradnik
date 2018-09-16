using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{
    public class RaspodjelaPoslaIndexVM
    {
    }

    public class RaspodjelaPoslaIndexRow
    {
        public int GradilisteId { get; set; }
        public string Gradiliste { get; set; }
        public string TipPosla { get; set; }
        public int TTipPoslaId { get; set; }
    }
}