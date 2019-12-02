using AccentureProyectoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureProyectoIntegrador.Controllers
{
    public class EditorialController : Controller
    {
        private AccentureProyectoIntegradorEntities db;

        public EditorialController()
        {
            this.db = new AccentureProyectoIntegradorEntities();
        }

        // Métodos LISTAR
        public ActionResult Listar()
        {
            List<Editoriales> editoriales = this.db.Editoriales.OrderBy(e => e.NombreEditorial).ToList();
            return View(editoriales);
        }

        public ActionResult JsonListar()
        {
            List<Editoriales> editoriales = this.db.Editoriales.OrderBy(e => e.NombreEditorial).ToList();
            return Json(editoriales, JsonRequestBehavior.AllowGet);
        }

        // Métodos EDITAR
        public ActionResult Editar(int id)
        {
            this.ViewBag.TituloPagina = "Editar Editorial";
            Editoriales editorial = this.db.Editoriales.Find(id);
            return View(editorial);
        }

        [HttpPost]
        public ActionResult Editar(Editoriales editorial)
        {
            if (this.ModelState.IsValid) {
                this.db.Editoriales.Add(editorial);
                this.db.Entry(editorial).State = EntityState.Modified;
                this.db.SaveChanges();
                return Content("Actualización de Editorial correcta.");
            }
            return new HttpStatusCodeResult(500, "Error de Servidor.");
        }

        // Método Agregar

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
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();
            Editoriales nuevaEditorial = new Editoriales();
            nuevaEditorial.NombreEditorial = NombreEditorial;

            db.Editoriales.Add(nuevaEditorial);
            db.SaveChanges(); ;
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            this.ViewBag.TituloPagina = "Agregar Editorial";
            Editoriales editorial = new Editoriales();
            return View("Editar", editorial);
        }

        [HttpPost]
        public ActionResult Agregar(Editoriales editorial)
        {
            this.db.Editoriales.Add(editorial);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        // Método Eliminar
        public ActionResult Eliminar(int id)
        {
            Editoriales editorial = this.db.Editoriales.Find(id);
            this.db.Editoriales.Remove(editorial);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}