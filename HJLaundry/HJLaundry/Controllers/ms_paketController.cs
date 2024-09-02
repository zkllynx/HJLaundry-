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
    public class ms_paketController : Controller
    {
        private laundryEntities db = new laundryEntities();

        // GET: ms_paket
        public ActionResult Index()
        {
            return View(db.ms_paket.ToList());
        }

        // GET: ms_paket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_paket ms_paket = db.ms_paket.Find(id);
            if (ms_paket == null)
            {
                return HttpNotFound();
            }
            return View(ms_paket);
        }

        // GET: ms_paket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ms_paket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_paket,nama_paket,harga,keterangan,status")] ms_paket ms_paket)
        {
            if (ModelState.IsValid)
            {
                db.ms_paket.Add(ms_paket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ms_paket);
        }

        // GET: ms_paket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_paket ms_paket = db.ms_paket.Find(id);
            if (ms_paket == null)
            {
                return HttpNotFound();
            }
            return View(ms_paket);
        }

        // POST: ms_paket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_paket,nama_paket,harga,keterangan,status")] ms_paket ms_paket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ms_paket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ms_paket);
        }

        // GET: ms_paket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_paket ms_paket = db.ms_paket.Find(id);
            if (ms_paket == null)
            {
                return HttpNotFound();
            }
            return View(ms_paket);
        }

        // POST: ms_paket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ms_paket ms_paket = db.ms_paket.Find(id);
            db.ms_paket.Remove(ms_paket);
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
