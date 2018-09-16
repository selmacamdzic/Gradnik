using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulSefGradilista.Models
{

    public class TipPoslaVM
    {
        public List<TipPoslaRowVM> listTipPosla { get; set; }
        public int GradilisteId { get; set; }
    }

    public class TipPoslaRowVM
    {
        public int TipPoslaId { get; set; }

        public string TipPoslaNaziv { get; set; }

        public int count { get; set; }
    }
}