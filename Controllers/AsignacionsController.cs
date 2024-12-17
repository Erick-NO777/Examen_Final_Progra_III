using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructoraUH.Data;
using ConstructoraUH.Models;

namespace ConstructoraUH.Controllers
{
    public class AsignacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Asignacions
        public ActionResult Index()
        {
            var asignacions = db.Asignacions.Include(a => a.Empleado).Include(a => a.Proyecto);
            return View(asignacions.ToList());
        }

        // GET: Asignacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignacions.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            return View(asignacion);
        }

        // GET: Asignacions/Create
        public ActionResult Create()
        {
            ViewBag.CarnetUnico = new SelectList(db.Empleadoes, "CarnetUnico", "NombreCompleto");
            ViewBag.CodigoProyecto = new SelectList(db.Proyectoes, "CodigoProyecto", "Nombre");
            return View();
        }

        // POST: Asignacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAsignacion,CarnetUnico,CodigoProyecto,FechaAsignacion")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                db.Asignacions.Add(asignacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarnetUnico = new SelectList(db.Empleadoes, "CarnetUnico", "NombreCompleto", asignacion.CarnetUnico);
            ViewBag.CodigoProyecto = new SelectList(db.Proyectoes, "CodigoProyecto", "Nombre", asignacion.CodigoProyecto);
            return View(asignacion);
        }

        // GET: Asignacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignacions.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarnetUnico = new SelectList(db.Empleadoes, "CarnetUnico", "NombreCompleto", asignacion.CarnetUnico);
            ViewBag.CodigoProyecto = new SelectList(db.Proyectoes, "CodigoProyecto", "Nombre", asignacion.CodigoProyecto);
            return View(asignacion);
        }

        // POST: Asignacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAsignacion,CarnetUnico,CodigoProyecto,FechaAsignacion")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarnetUnico = new SelectList(db.Empleadoes, "CarnetUnico", "NombreCompleto", asignacion.CarnetUnico);
            ViewBag.CodigoProyecto = new SelectList(db.Proyectoes, "CodigoProyecto", "Nombre", asignacion.CodigoProyecto);
            return View(asignacion);
        }

        // GET: Asignacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignacions.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            return View(asignacion);
        }

        // POST: Asignacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignacion asignacion = db.Asignacions.Find(id);
            db.Asignacions.Remove(asignacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
