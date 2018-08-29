using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterDetailJS.Models;

namespace MasterDetailJS.Controllers
{
    public class TunnitController : Controller
    {
        private MasterDetailJSEntities db = new MasterDetailJSEntities();

        // GET: Tunnit
        public ActionResult Index()
        {
            List<Tunnit> model = new List<Tunnit>();
            MasterDetailJSEntities entities = new MasterDetailJSEntities();

            try
            {
                List<Tunnit> tunnit = entities.Tunnit.OrderByDescending(Tunnit => Tunnit.TuntiId).ToList();
                foreach (Tunnit tunti in tunnit)
                {
                    Tunnit tun = new Tunnit();
                    tun.TuntiId = tunti.TuntiId;
                    tun.ProjektiId = tunti.ProjektiId;
                    tun.HenkiloId = tunti.HenkiloId;
                    tun.Pvm = tunti.Pvm;
                    tun.Tunnit1 = tunti.Tunnit1;

                    model.Add(tun);
                }

                return View(model);
            }

            finally
            {
                entities.Dispose();
            }
        }

        CultureInfo fiFi = new CultureInfo("fi-FI");

        // GET: Tunnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tunnit tunnit = db.Tunnit.Find(id);
            if (tunnit == null)
            {
                return HttpNotFound();
            }
            return View(tunnit);
        }

        // GET: Tunnits/Create
        public ActionResult Create()
        {
            MasterDetailJSEntities db = new MasterDetailJSEntities();

            Tunnit model = new Tunnit();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tunnit model)
        {
            MasterDetailJSEntities db = new MasterDetailJSEntities();

            Tunnit tunnit = new Tunnit();
            tunnit.TuntiId = model.TuntiId;
            tunnit.ProjektiId = model.ProjektiId;
            tunnit.HenkiloId = model.HenkiloId;
            tunnit.Pvm = model.Pvm;
            tunnit.Tunnit1 = model.Tunnit1;

            db.Tunnit.Add(tunnit);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }

        // GET: Tunnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tunnit tunnit = db.Tunnit.Find(id);
            if (tunnit == null)
            {
                return HttpNotFound();
            }
            Tunnit tun = new Tunnit();
            tun.TuntiId = tunnit.TuntiId;
            tun.ProjektiId = tunnit.ProjektiId;
            tun.HenkiloId = tunnit.HenkiloId;
            tun.Pvm = tunnit.Pvm;
            tun.Tunnit1 = tunnit.Tunnit1;

            return View(tun);
        }

        // POST: Tunnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tunnit model)
        {
            Tunnit tun = db.Tunnit.Find(model.TuntiId);
            tun.ProjektiId = model.ProjektiId;
            tun.HenkiloId = model.HenkiloId;
            tun.Pvm = model.Pvm;
            tun.Tunnit1 = model.Tunnit1;

            db.SaveChanges();

            return RedirectToAction("Index");
        }//edit 

        // GET: Tunnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tunnit tunti = db.Tunnit.Find(id);
            if (tunti == null)
            {
                return HttpNotFound();
            }
            Tunnit tun = new Tunnit();
            tun.TuntiId = tunti.TuntiId;
            tun.ProjektiId = tunti.ProjektiId;
            tun.HenkiloId = tunti.HenkiloId;
            tun.Pvm = tunti.Pvm;
            tun.Tunnit1 = tunti.Tunnit1;

            return View(tun);
        }

        // POST: Tunnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tunnit tunti = db.Tunnit.Find(id);
            db.Tunnit.Remove(tunti);
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

