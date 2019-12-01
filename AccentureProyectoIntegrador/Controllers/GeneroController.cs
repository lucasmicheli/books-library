using AccentureProyectoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureProyectoIntegrador.Controllers
{
    public class GeneroController : Controller
    {
        public ActionResult Mostrar()
        {
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();
            List<Generos> generos = db.Generos.OrderBy(g => g.NombreGenero).ToList();
            return View();
        }
        public ActionResult Crear(string NombreGenero)
        {
            if (NombreGenero == null)
            {
                return Content("Debe insertar un nombre de género.");
            }

            if (NombreGenero.Length == 0)
            {
                return Content("Debe insertar un nombre de género.");
            }
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();
            Generos nuevoGenero = new Generos();
            nuevoGenero.NombreGenero = NombreGenero;

            db.Generos.Add(nuevoGenero);
            db.SaveChanges(); ;
            return RedirectToAction("Mostrar");
        }

        public ActionResult Nuevo()
        {
            return View("Crear");
        }
        [HttpPost]
        public ActionResult Nuevo(Generos nuevoGenero)
        {
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();
            db.Generos.Add(nuevoGenero);
            db.SaveChanges();
            return RedirectToAction("Mostrar");
        }
    }
}