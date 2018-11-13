using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gradnik_Web.Models
{
	public class PotrosnjaMaterijalaDto
	{
        public string Materijal { get; set; }
        public int GradilisteId { get; set; }
        public int Kolicina { get; set; }
    }
}