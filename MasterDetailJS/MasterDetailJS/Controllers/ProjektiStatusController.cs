

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterDetailJS.Models;

namespace MasterDetailJS.Controllers
{
    public class ProjektiStatusController : Controller
    {
        private MasterDetailJSEntities db = new MasterDetailJSEntities();

        // add another MVC action for return JSON data
        // for showing in react JS component
        public JsonResult getmessage()
        {
            return new JsonResult
            {
                Data = "Hello World. I am from server-side",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        // GET: ProjektiStatus
        public ActionResult Index()
        {
            return View(db.Projektit.ToList());
        }

        // GET: ProjektiStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projektit projektit = db.Projektit.Find(id);
            if (projektit == null)
            {
                return HttpNotFound();
            }
            return View(projektit);
        }

        // GET: ProjektiStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjektiStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjektiId,Nimi,Status")] Projektit projektit)
        {
            if (ModelState.IsValid)
            {
                db.Projektit.Add(projektit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projektit);
        }

        // GET: ProjektiStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projektit projektit = db.Projektit.Find(id);
            if (projektit == null)
            {
                return HttpNotFound();
            }
            return View(projektit);
        }

        // POST: ProjektiStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjektiId,Nimi,Status")] Projektit projektit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projektit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projektit);
        }

        // GET: ProjektiStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projektit projektit = db.Projektit.Find(id);
            if (projektit == null)
            {
                return HttpNotFound();
            }
            return View(projektit);
        }

        // POST: ProjektiStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projektit projektit = db.Projektit.Find(id);
            db.Projektit.Remove(projektit);
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
