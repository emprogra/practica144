using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reporte.Models
{
    public class Reporte
    {
        [Key]
        public int PerosnId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CovidCount { get; set; }
    }
}