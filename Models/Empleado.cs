using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUH.Models
{
    public class Empleado
    {
        [Key]
        public int CarnetUnico { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; } = "San José";

        [Required]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [Range(250000, 500000)]
        public decimal Salario { get; set; } = 250000;

        [Required]
        public string CategoriaLaboral { get; set; }
    }
}