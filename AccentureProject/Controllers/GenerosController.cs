using AccentureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureProject.Controllers
{
    public class GenerosController : Controller
    {
        public ActionResult Mostrar()
        {
            AccentureProjectEntities db = new AccentureProjectEntities();
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
            AccentureProjectEntities db = new AccentureProjectEntities();
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
            AccentureProjectEntities db = new AccentureProjectEntities();
            db.Generos.Add(nuevoGenero);
            db.SaveChanges();
            return RedirectToAction("Mostrar");
        }
    }
}