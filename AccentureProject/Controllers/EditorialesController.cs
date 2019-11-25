using AccentureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureProject.Controllers
{
    public class EditorialesController : Controller
    {
        public ActionResult Mostrar()
        {
            AccentureProjectEntities db = new AccentureProjectEntities();
            List<Editoriales> editoriales = db.Editoriales.OrderBy(e => e.NombreEditorial).ToList();
            return View();
        }
        public ActionResult Crear(string NombreEditorial)
        {
            if (NombreEditorial == null)
            {
                return Content("Debe insertar un nombre de editorial.");
            }

            if (NombreEditorial.Length == 0)
            {
                return Content("Debe insertar un nombre de editorial.");
            }
            AccentureProjectEntities db = new AccentureProjectEntities();
            Editoriales nuevaEditorial = new Editoriales();
            nuevaEditorial.NombreEditorial = NombreEditorial;

            db.Editoriales.Add(nuevaEditorial);
            db.SaveChanges();;
            return RedirectToAction("Mostrar");
        }

        public ActionResult Nuevo()
        {
            return View("Crear");
        }
        [HttpPost]
        public ActionResult Nuevo(Editoriales nuevaEditorial)
        {
            AccentureProjectEntities db = new AccentureProjectEntities();
            db.Editoriales.Add(nuevaEditorial);
            db.SaveChanges();
            return RedirectToAction("Mostrar");
        }
    }
}