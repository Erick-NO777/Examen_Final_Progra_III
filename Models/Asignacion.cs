using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUH.Models
{
    public class Asignacion
    {
        [Key]
        public int IdAsignacion { get; set; }

        [Required]
        public int CarnetUnico { get; set; }

        [ForeignKey("CarnetUnico")]
        public Empleado Empleado { get; set; }

        [Required]
        public int CodigoProyecto { get; set; }

        [ForeignKey("CodigoProyecto")]
        public Proyecto Proyecto { get; set; }

        public DateTime FechaAsignacion { get; set; } = DateTime.Now;
    }
}