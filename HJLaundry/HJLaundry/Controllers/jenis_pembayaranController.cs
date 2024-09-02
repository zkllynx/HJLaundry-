using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HJLaundry.Models;

namespace HJLaundry.Controllers
{
    public class jenis_pembayaranController : Controller
    {
        private laundryEntities db = new laundryEntities();

        // GET: jenis_pembayaran
        public ActionResult Index()
        {
            return View(db.jenis_pembayaran.ToList());
        }

        // GET: jenis_pembayaran/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jenis_pembayaran jenis_pembayaran = db.jenis_pembayaran.Find(id);
            if (jenis_pembayaran == null)
            {
                return HttpNotFound();
            }
            return View(jenis_pembayaran);
        }

        // GET: jenis_pembayaran/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: jenis_pembayaran/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_jenis_pembayaran,nama_jenis_pembayaran,status")] jenis_pembayaran jenis_pembayaran)
        {
            if (ModelState.IsValid)
            {
                db.jenis_pembayaran.Add(jenis_pembayaran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jenis_pembayaran);
        }

        // GET: jenis_pembayaran/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jenis_pembayaran jenis_pembayaran = db.jenis_pembayaran.Find(id);
            if (jenis_pembayaran == null)
            {
                return HttpNotFound();
            }
            return View(jenis_pembayaran);
        }

        // POST: jenis_pembayaran/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_jenis_pembayaran,nama_jenis_pembayaran,status")] jenis_pembayaran jenis_pembayaran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jenis_pembayaran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jenis_pembayaran);
        }

        // GET: jenis_pembayaran/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jenis_pembayaran jenis_pembayaran = db.jenis_pembayaran.Find(id);
            if (jenis_pembayaran == null)
            {
                return HttpNotFound();
            }
            return View(jenis_pembayaran);
        }

        // POST: jenis_pembayaran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            jenis_pembayaran jenis_pembayaran = db.jenis_pembayaran.Find(id);
            db.jenis_pembayaran.Remove(jenis_pembayaran);
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
