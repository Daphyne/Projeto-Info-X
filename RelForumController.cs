using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PI_INFOX.Models.Basicas;

namespace PI_INFOX.Controllers
{
    public class RelForumController : Controller
    {
        private dbInfoXContext db = new dbInfoXContext();

        //
        // GET: /RelForum/

        public ActionResult Index()
        {
            var professores = db.Professores.Include(b => b.Disciplinas);
            return View(professores.ToList());
        }

        //
        // GET: /RelForum/Details/5

        public ActionResult Details(int id = 0)
        {
            basProfessor basprofessor = db.Professores.Find(id);
            if (basprofessor == null)
            {
                return HttpNotFound();
            }
            return View(basprofessor);
        }

        //
        // GET: /RelForum/Create

        public ActionResult Create()
        {
            ViewBag.DisciplinaID = new SelectList(db.Disciplinas, "DisciplinaID", "nomeDisciplina");
            return View();
        }

        //
        // POST: /RelForum/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(basProfessor basprofessor)
        {
            if (ModelState.IsValid)
            {
                db.Professores.Add(basprofessor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisciplinaID = new SelectList(db.Disciplinas, "DisciplinaID", "nomeDisciplina", basprofessor.DisciplinaID);
            return View(basprofessor);
        }

        //
        // GET: /RelForum/Edit/5

        public ActionResult Edit(int id = 0)
        {
            basProfessor basprofessor = db.Professores.Find(id);
            if (basprofessor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplinaID = new SelectList(db.Disciplinas, "DisciplinaID", "nomeDisciplina", basprofessor.DisciplinaID);
            return View(basprofessor);
        }

        //
        // POST: /RelForum/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(basProfessor basprofessor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basprofessor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisciplinaID = new SelectList(db.Disciplinas, "DisciplinaID", "nomeDisciplina", basprofessor.DisciplinaID);
            return View(basprofessor);
        }

        //
        // GET: /RelForum/Delete/5

        public ActionResult Delete(int id = 0)
        {
            basProfessor basprofessor = db.Professores.Find(id);
            if (basprofessor == null)
            {
                return HttpNotFound();
            }
            return View(basprofessor);
        }

        //
        // POST: /RelForum/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            basProfessor basprofessor = db.Professores.Find(id);
            db.Professores.Remove(basprofessor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}