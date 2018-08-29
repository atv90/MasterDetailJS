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
    public class ProjektitController : Controller
    {
        private MasterDetailJSEntities db = new MasterDetailJSEntities();

        // GET: Projektit
        public ActionResult Index()
        {
            List<Projektit> model = new List<Projektit>();
            MasterDetailJSEntities entities = new MasterDetailJSEntities();
            try
            {
                List<Projektit> projektit = entities.Projektit.OrderByDescending(Projektit => Projektit.ProjektiId).ToList();
                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (Projektit projekti in projektit)
                {
                    Projektit pro = new Projektit();
                    pro.ProjektiId = projekti.ProjektiId;
                    pro.Nimi = projekti.Nimi;

                    model.Add(pro);
                }

                return View(model);
            }

            finally
            {
                entities.Dispose();
            }
        }


        // GET: Projektits/Details/5
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

        // GET: Projektits/Create
        public ActionResult Create()
        {
            MasterDetailJSEntities db = new MasterDetailJSEntities();

            Projektit model = new Projektit();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Projektit model)
        {
            MasterDetailJSEntities db = new MasterDetailJSEntities();

            Projektit projektit = new Projektit();
            projektit.ProjektiId = model.ProjektiId;
            projektit.Nimi = model.Nimi;

            db.Projektit.Add(projektit);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }

        // GET: Projektits/Edit/5
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

            Projektit pro = new Projektit();
            pro.ProjektiId = projektit.ProjektiId;
            pro.Nimi = projektit.Nimi;

            return View(pro);
        }

        // POST: Projektits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Projektit model)
        {
            Projektit pro = db.Projektit.Find(model.ProjektiId);
            pro.Nimi = model.Nimi;

            db.SaveChanges();

            return RedirectToAction("Index");
        }//edit 

        // GET: Projektits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projektit projekti = db.Projektit.Find(id);
            if (projekti == null)
            {
                return HttpNotFound();
            }

            Projektit pro = new Projektit();
            pro.ProjektiId = projekti.ProjektiId;
            pro.Nimi = projekti.Nimi;
            return View(pro);
        }

        // POST: Projektits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projektit projekti = db.Projektit.Find(id);
            db.Projektit.Remove(projekti);
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