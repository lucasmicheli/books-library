using AccentureProyectoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureProyectoIntegrador.Controllers
{
    public class GeneroController : Controller
    {

        private AccentureProyectoIntegradorEntities db;

        public GeneroController()
        {
            this.db = new AccentureProyectoIntegradorEntities();
        }

        // Métodos LISTAR
        public ActionResult Listar()
        {
            List<Generos> generos = this.db.Generos.OrderBy(g => g.NombreGenero).ToList();
            return View(generos);
        }

        public ActionResult JsonListar()
        {
            List<Generos> generos = this.db.Generos.OrderBy(g => g.NombreGenero).ToList();
            return Json(generos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Mostrar()
        {
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();
            List<Generos> generos = db.Generos.OrderBy(g => g.NombreGenero).ToList();
            return View();
        }

        // Métodos EDITAR
        public ActionResult Editar(int id)
        {
            this.ViewBag.TituloPagina = "Editar Género";
            Generos genero = this.db.Generos.Find(id);
            return View(genero);
        }

        [HttpPost]
        public ActionResult Editar(Generos genero)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Generos.Add(genero);
                this.db.Entry(genero).State = EntityState.Modified;
                this.db.SaveChanges();
                return Content("Actualización de Género correcta.");
            }
            return new HttpStatusCodeResult(500, "Error de Servidor.");
        }

        // Método Agregar

        public ActionResult Agregar()
        {
            this.ViewBag.TituloPagina = "Agregar Género";
            Generos genero = new Generos();
            return View("Editar", genero);
        }

        [HttpPost]
        public ActionResult Agregar(Generos genero)
        {
            this.db.Generos.Add(genero);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
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

        // Método Eliminar
        public ActionResult Eliminar(int id)
        {
            Generos genero = this.db.Generos.Find(id);
            this.db.Generos.Remove(genero);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}