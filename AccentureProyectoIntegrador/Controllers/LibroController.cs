using AccentureProyectoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureProyectoIntegrador.Controllers
{
    public class LibroController : Controller
    {
        public ActionResult Agregar()
        {
            return View("Editar");
        }

        [HttpPost]
        public ActionResult Agregar(Libros libro, IEnumerable<int> autores)
        {
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();

            foreach (int autorActual in autores)
            {
                Autores autor = db.Autores.Find(autorActual);
                libro.Autores.Add(autor);

            }
            db.Libros.Add(libro);
            db.SaveChanges();
            return Content("Libro añadido satisfactoriamente.");
        }

        public ActionResult Editar(int id)
        {
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();
            Libros libro = db.Libros.Find(id);
            return View(libro);
        }

        [HttpPost]
        public ActionResult Editar(Libros libro, IEnumerable<int> autores)
        {
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();

            Libros libroA = db.Libros.Find(libro.IdLibro);
            libroA.Titulo = libro.Titulo;
            libroA.Autores.Clear();

            foreach (int autorActual in autores)
            {
                Autores escritoPor = db.Autores.Find(autorActual);
                libroA.Autores.Add(escritoPor);

            }
            db.SaveChanges();
            return Content("Libro editado satisfactoriamente.");
        }

        public ActionResult Listar()
        {
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();
            return View(db.Libros.ToList());
        }

        [HttpPost]
        public ActionResult Listar(ListarViewModel filtros)
        {
            AccentureProyectoIntegradorEntities db = new AccentureProyectoIntegradorEntities();

            IQueryable<Libros> qry = db.Libros;

            if (filtros.FiltroTitulo != null)
            {
                qry = qry.Where(lib => lib.Titulo.Contains(filtros.FiltroTitulo));
            }

            if (filtros.FiltroAutor.HasValue)
            {
                qry = qry.Where(lib => lib.Autores.Any(
                    aut => aut.IdAutor.Equals(filtros.FiltroAutor.Value)
                    ));
            }
            return View(qry.ToList());
        }
    }
}