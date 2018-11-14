using Gradnik_Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Gradnik_Web.Areas.ModulReferent.Models
{
    public class EvidencijaRadnogVremena
    {
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public int GradilisteId { get; set; }
        public List<SelectListItem> Gradilista { get; set; }
        public List<EvidencijaIsplateDto> EvidencijaIsplate { get; set; }
    }
}