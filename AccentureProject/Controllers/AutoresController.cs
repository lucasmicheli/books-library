using AccentureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureProject.Controllers
{
    public class AutoresController : Controller
    {
        public ActionResult Mostrar()
        {
            AccentureProjectEntities db = new AccentureProjectEntities();
            List<Autores> autores = db.Autores.OrderBy(a => a.Nombre).ToList();
            return View();
        }
        public ActionResult Crear(string NombreAutor)
        {
            if (NombreAutor == null)
            {
                return Content("Debe insertar un nombre de autor válido.");
            }

            if (NombreAutor.Length == 0)
            {
                return Content("Debe insertar un nombre de autor válido.");
            }
            AccentureProjectEntities db = new AccentureProjectEntities();
            Autores nuevoAutor = new Autores();
            nuevoAutor.Nombre = NombreAutor;

            db.Autores.Add(nuevoAutor);
            db.SaveChanges(); ;
            return RedirectToAction("Mostrar");
        }

        public ActionResult Nuevo()
        {
            return View("Crear");
        }
        [HttpPost]
        public ActionResult Nuevo(Autores nuevoAutor)
        {
            AccentureProjectEntities db = new AccentureProjectEntities();
            db.Autores.Add(nuevoAutor);
            db.SaveChanges();
            return RedirectToAction("Mostrar");
        }
    }
}