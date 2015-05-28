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
    public class MensagemForumController : Controller
    {
        private dbInfoXContext db = new dbInfoXContext();

        //
        // GET: /MensagemForum/

        public ActionResult Index()
        {
            var mensagemforums = db.MensagemForums.Include(b => b.Alunos);
            return View(mensagemforums.ToList());
        }

        //
        // GET: /MensagemForum/Details/5

        public ActionResult Details(int id = 0)
        {
            basMensagemForum basmensagemforum = db.MensagemForums.Find(id);
            if (basmensagemforum == null)
            {
                return HttpNotFound();
            }
            return View(basmensagemforum);
        }

        //
        // GET: /MensagemForum/Create

        public ActionResult Create()
        {
            ViewBag.matriculaAlunoID = new SelectList(db.Alunos, "matriculaAlunoID", "email");
            return View();
        }

        //
        // POST: /MensagemForum/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(basMensagemForum basmensagemforum)
        {
            if (ModelState.IsValid)
            {
                db.MensagemForums.Add(basmensagemforum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.matriculaAlunoID = new SelectList(db.Alunos, "matriculaAlunoID", "email", basmensagemforum.matriculaAlunoID);
            return View(basmensagemforum);
        }

        //
        // GET: /MensagemForum/Edit/5

        public ActionResult Edit(int id = 0)
        {
            basMensagemForum basmensagemforum = db.MensagemForums.Find(id);
            if (basmensagemforum == null)
            {
                return HttpNotFound();
            }
            ViewBag.matriculaAlunoID = new SelectList(db.Alunos, "matriculaAlunoID", "email", basmensagemforum.matriculaAlunoID);
            return View(basmensagemforum);
        }

        //
        // POST: /MensagemForum/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(basMensagemForum basmensagemforum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basmensagemforum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.matriculaAlunoID = new SelectList(db.Alunos, "matriculaAlunoID", "email", basmensagemforum.matriculaAlunoID);
            return View(basmensagemforum);
        }

        //
        // GET: /MensagemForum/Delete/5

        public ActionResult Delete(int id = 0)
        {
            basMensagemForum basmensagemforum = db.MensagemForums.Find(id);
            if (basmensagemforum == null)
            {
                return HttpNotFound();
            }
            return View(basmensagemforum);
        }

        //
        // POST: /MensagemForum/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            basMensagemForum basmensagemforum = db.MensagemForums.Find(id);
            db.MensagemForums.Remove(basmensagemforum);
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