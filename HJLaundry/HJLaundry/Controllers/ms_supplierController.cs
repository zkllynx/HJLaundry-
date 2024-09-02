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
    public class ms_supplierController : Controller
    {
        private laundryEntities db = new laundryEntities();

        // GET: ms_supplier
        public ActionResult Index()
        {
            return View(db.ms_supplier.ToList());
        }

        // GET: ms_supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_supplier ms_supplier = db.ms_supplier.Find(id);
            if (ms_supplier == null)
            {
                return HttpNotFound();
            }
            return View(ms_supplier);
        }

        // GET: ms_supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ms_supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_supplier,nama_supplier,alamat_supplier,telp_supplier,status")] ms_supplier ms_supplier)
        {
            if (ModelState.IsValid)
            {
                db.ms_supplier.Add(ms_supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ms_supplier);
        }

        // GET: ms_supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_supplier ms_supplier = db.ms_supplier.Find(id);
            if (ms_supplier == null)
            {
                return HttpNotFound();
            }
            return View(ms_supplier);
        }

        // POST: ms_supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_supplier,nama_supplier,alamat_supplier,telp_supplier,status")] ms_supplier ms_supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ms_supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ms_supplier);
        }

        // GET: ms_supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_supplier ms_supplier = db.ms_supplier.Find(id);
            if (ms_supplier == null)
            {
                return HttpNotFound();
            }
            return View(ms_supplier);
        }

        // POST: ms_supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ms_supplier ms_supplier = db.ms_supplier.Find(id);
            db.ms_supplier.Remove(ms_supplier);
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
