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
    public class HenkilotController : Controller
    {
        private MasterDetailJSEntities db = new MasterDetailJSEntities();

        // GET: Henkilot
        public ActionResult Index()
        {
            List<SimplyHenkilotData> model = new List<SimplyHenkilotData>();
            MasterDetailJSEntities entities = new MasterDetailJSEntities();
            try
            {
                List<Henkilot> henkilot = entities.Henkilot.OrderByDescending(Henkilot => Henkilot.HenkiloId).ToList();
                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (Henkilot henkilo in henkilot)
                {
                    SimplyHenkilotData hlo = new SimplyHenkilotData();
                    hlo.HenkiloId = henkilo.HenkiloId;
                    hlo.Etunimi = henkilo.Etunimi;
                    hlo.Sukunimi = henkilo.Sukunimi;
                    hlo.Osoite = henkilo.Osoite;
                    hlo.Esimies = henkilo.Esimies;

                    model.Add(hlo);
                }


                return View(model);
        }
            finally
            {
                entities.Dispose();
            }
        }

        //Alikyselyyn
        //int? kysymysmerkki mahdollistaa myös nolla-arvot parametrille
        public ActionResult GetTunnit(int? id)
        {
            MasterDetailJSEntities entities = new MasterDetailJSEntities();

            List<Tunnit> tunnit = (from t in entities.Tunnit
                                   where t.HenkiloId == id
                                   select t).ToList();

            List<SimplyTunnitData> result = new List<SimplyTunnitData>();

            CultureInfo fiFi = new CultureInfo("fi-FI");

            foreach (Tunnit tunti in tunnit)
            {
                SimplyTunnitData data = new SimplyTunnitData();

                data.TuntiId = tunti.TuntiId;
                data.HenkiloId = (int)(tunti.HenkiloId);
                data.Pvm = tunti.Pvm.Value.ToString(fiFi);
                data.Tunnit1 = (int)tunti.Tunnit1;

                List<Projektit> projektit = (from p in entities.Projektit
                                             where p.ProjektiId == tunti.ProjektiId
                                             select p).ToList();

                data.ProjektiNimi = projektit[0].Nimi;
                data.ProjektiStatus = projektit[0].Status;

                result.Add(data);
            }

            entities.Dispose();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: ProjektiStatus
        public ActionResult ProjektiStatus()
        {
            List<SimplyHenkilotData> model = new List<SimplyHenkilotData>();
            MasterDetailJSEntities entities = new MasterDetailJSEntities();
            try
            {
                List<Henkilot> henkilot = entities.Henkilot.OrderByDescending(Henkilot => Henkilot.HenkiloId).ToList();
                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (Henkilot henkilo in henkilot)
                {
                    SimplyHenkilotData hlo = new SimplyHenkilotData();
                    hlo.HenkiloId = henkilo.HenkiloId;
                    hlo.Etunimi = henkilo.Etunimi;
                    hlo.Sukunimi = henkilo.Sukunimi;
                    hlo.Osoite = henkilo.Osoite;
                    hlo.Esimies = henkilo.Esimies;

                    model.Add(hlo);
                }


                return View(model);
            }
            finally
            {
                entities.Dispose();
            }
        }

        //ProjektinStatus-Alikyselyyn
        //int? kysymysmerkki mahdollistaa myös nolla-arvot parametrille
        public ActionResult AnnaTunnit(int? id)
        {
            MasterDetailJSEntities entities = new MasterDetailJSEntities();

            List<Tunnit> tunnit = (from t in entities.Tunnit
                                   where t.HenkiloId == id
                                   select t).ToList();

            List<SimplyTunnitData> result = new List<SimplyTunnitData>();

            CultureInfo fiFi = new CultureInfo("fi-FI");

            foreach (Tunnit tunti in tunnit)
            {
                SimplyTunnitData data = new SimplyTunnitData();

                data.TuntiId = tunti.TuntiId;
                data.HenkiloId = (int)(tunti.HenkiloId);
                data.Pvm = tunti.Pvm.Value.ToString(fiFi);
                data.Tunnit1 = (int)tunti.Tunnit1;
                

                List<Projektit> projektit = (from p in entities.Projektit
                                             where p.ProjektiId == tunti.ProjektiId
                                             select p).ToList();

                data.ProjektiNimi = projektit[0].Nimi;
                data.ProjektiStatus = projektit[0].Status;

                result.Add(data);
            }

            entities.Dispose();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmployeeData()
        {
            using (MasterDetailJSEntities dc = new MasterDetailJSEntities())
            {
                var data = dc.Henkilot.ToList();
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // GET: Henkilots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilot henkilot = db.Henkilot.Find(id);
            if (henkilot == null)
            {
                return HttpNotFound();
            }
            return View(henkilot);
        }

        // GET: Henkilots/Create
        public ActionResult Create()
        {
            MasterDetailJSEntities db = new MasterDetailJSEntities();

            SimplyHenkilotData model = new SimplyHenkilotData();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SimplyHenkilotData model)
        {
            MasterDetailJSEntities db = new MasterDetailJSEntities();

            //luodaan Henkilot-luokkaan uusi olio
            Henkilot henkilot = new Henkilot();
            henkilot.HenkiloId = model.HenkiloId;
            henkilot.Etunimi = model.Etunimi;
            henkilot.Sukunimi = model.Sukunimi;
            henkilot.Osoite = model.Osoite;
            henkilot.Esimies = model.Esimies;

            db.Henkilot.Add(henkilot);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }


        // GET: Henkilots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilot henkilo = db.Henkilot.Find(id);
            if (henkilo == null)
            {
                return HttpNotFound();
            }

            //muokataan jo olemassa olevaa
            SimplyHenkilotData hlo = new SimplyHenkilotData();
            hlo.HenkiloId = henkilo.HenkiloId;
            hlo.Etunimi = henkilo.Etunimi;
            hlo.Sukunimi = henkilo.Sukunimi;
            hlo.Osoite = henkilo.Osoite;
            hlo.Esimies = henkilo.Esimies;

            return View(hlo);
        }

        // POST: Henkilots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SimplyHenkilotData model)
        {
            Henkilot hlo = db.Henkilot.Find(model.HenkiloId);
            hlo.Etunimi = model.Etunimi;
            hlo.Sukunimi = model.Sukunimi;
            hlo.Osoite = model.Osoite;
            hlo.Esimies = model.Esimies;

            db.SaveChanges();

            return RedirectToAction("Index");
        }//edit 


        // GET: Henkilots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilot henkilo = db.Henkilot.Find(id);
            if (henkilo == null)
            {
                return HttpNotFound();
            }

            SimplyHenkilotData hlo = new SimplyHenkilotData();
            hlo.HenkiloId = henkilo.HenkiloId;
            hlo.Etunimi = henkilo.Etunimi;
            hlo.Sukunimi = henkilo.Sukunimi;
            hlo.Osoite = henkilo.Osoite;
            hlo.Esimies = henkilo.Esimies;

            return View(hlo);
        }

        // POST: Henkilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Henkilot henkilo = db.Henkilot.Find(id);
            db.Henkilot.Remove(henkilo);
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

