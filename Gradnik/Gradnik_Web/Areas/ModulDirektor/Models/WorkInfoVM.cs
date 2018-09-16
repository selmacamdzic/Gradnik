using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Areas.ModulDirektor.Models
{
    public class WorkInfoVM
    {
        public WorkInfoRow workInfo;
    }

    public class WorkInfoRow
    {
        public int RaspodjelaPoslaId { get; set; }
        public string workareaName { get; set; }
        public string jobtitle { get; set; }
        public DateTime startDate { get; set; }
        public decimal hours { get; set; }
    }
}