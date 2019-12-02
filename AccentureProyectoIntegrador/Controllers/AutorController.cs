using AccentureProyectoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureProyectoIntegrador.Controllers
{
    public class AutorController : Controller
    {
        private AccentureProyectoIntegradorEntities db;

        public AutorController()
        {
            this.db = new AccentureProyectoIntegradorEntities();
        }

        // Métodos LISTAR
        public ActionResult Listar()
        {
            List<Autores> autores = this.db.Autores.OrderBy(a => a.NombreAutor).ToList();
            return View(autores);
        }

        public ActionResult JsonListar()
        {
            List<Autores> autores = this.db.Autores.OrderBy(a => a.NombreAutor).ToList();
            return Json(autores, JsonRequestBehavior.AllowGet);
        }

        // Métodos EDITAR
        public ActionResult Editar(int id)
        {
            this.ViewBag.TituloPagina = "Editar Autor";
            Autores autor = this.db.Autores.Find(id);
            return View(autor);
        }

        [HttpPost]
        public ActionResult Editar(Autores autor)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Autores.Add(autor);
                this.db.Entry(autor).State = EntityState.Modified;
                this.db.SaveChanges();
                return Content("Actualización de Autor correcta.");
            }
            return new HttpStatusCodeResult(500, "Error de Servidor.");
        }

        // Método Agregar

        public ActionResult Crear(string NombreAutor)
        {
            if (NombreAutor == null)
            {
                return Content("Debe insertar un nombre de autor.");
            }

            if (NombreAutor.Length == 0)
            {
                return Content("Debe insertar un nombre de autor.");
            }
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();
            Autores nuevoAutor = new Autores();
            nuevoAutor.NombreAutor = NombreAutor;

            db.Autores.Add(nuevoAutor);
            db.SaveChanges(); ;
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            this.ViewBag.TituloPagina = "Agregar Autor";
            Autores autor = new Autores();
            return View("Editar", autor);
        }

        [HttpPost]
        public ActionResult Agregar(Autores autor)
        {
            this.db.Autores.Add(autor);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        // Método Eliminar
        public ActionResult Eliminar(int id)
        {
            Autores autor = this.db.Autores.Find(id);
            this.db.Autores.Remove(autor);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}