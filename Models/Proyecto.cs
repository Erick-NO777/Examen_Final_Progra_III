using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUH.Models
{
    public class Proyecto
    {
        [Key]
        public int CodigoProyecto { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }
    }
}