using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConstructoraUH.Data; // Asegúrate de reemplazar el namespace correcto.
using ConstructoraUH.Models; // Asegúrate de que coincida con tus modelos.

namespace ConstructoraUH.Controllers
{
    public class PruebaController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            // Consulta simple para listar los empleados existentes
            var empleados = db.Empleadoes.ToList();

            // Devuelve los datos en la vista
            return Content("Número de empleados: " + empleados.Count);
        }
    }
}