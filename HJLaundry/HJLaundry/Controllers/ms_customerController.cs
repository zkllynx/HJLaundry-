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
    public class ms_customerController : Controller
    {
        private laundryEntities db = new laundryEntities();

        // GET: ms_customer
        public ActionResult Index()
        {
            return View(db.ms_customer.ToList());
        }

        // GET: ms_customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_customer ms_customer = db.ms_customer.Find(id);
            if (ms_customer == null)
            {
                return HttpNotFound();
            }
            return View(ms_customer);
        }

        // GET: ms_customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ms_customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_customer,nama_customer,telp_customer,alamat_customer,status")] ms_customer ms_customer)
        {
            if (ModelState.IsValid)
            {
                db.ms_customer.Add(ms_customer);
                ms_customer.status = 1;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ms_customer);
        }

        // GET: ms_customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_customer ms_customer = db.ms_customer.Find(id);
            if (ms_customer == null)
            {
                return HttpNotFound();
            }
            return View(ms_customer);
        }

        // POST: ms_customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_customer,nama_customer,telp_customer,alamat_customer,status")] ms_customer ms_customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ms_customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ms_customer);
        }

        // GET: ms_customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_customer ms_customer = db.ms_customer.Find(id);
            if (ms_customer == null)
            {
                return HttpNotFound();
            }
            return View(ms_customer);
        }

        // POST: ms_customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ms_customer ms_customer = db.ms_customer.Find(id);
            db.ms_customer.Remove(ms_customer);
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
