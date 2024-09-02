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
    public class ms_jabatanController : Controller
    {
        private laundryEntities db = new laundryEntities();

        // GET: ms_jabatan
        public ActionResult Index()
        {
            return View(db.ms_jabatan.ToList());
        }

        // GET: ms_jabatan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_jabatan ms_jabatan = db.ms_jabatan.Find(id);
            if (ms_jabatan == null)
            {
                return HttpNotFound();
            }
            return View(ms_jabatan);
        }

        // GET: ms_jabatan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ms_jabatan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_jabatan,nama_jabatan,status")] ms_jabatan ms_jabatan)
        {
            if (ModelState.IsValid)
            {
                db.ms_jabatan.Add(ms_jabatan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ms_jabatan);
        }

        // GET: ms_jabatan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_jabatan ms_jabatan = db.ms_jabatan.Find(id);
            if (ms_jabatan == null)
            {
                return HttpNotFound();
            }
            return View(ms_jabatan);
        }

        // POST: ms_jabatan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_jabatan,nama_jabatan,status")] ms_jabatan ms_jabatan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ms_jabatan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ms_jabatan);
        }

        // GET: ms_jabatan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_jabatan ms_jabatan = db.ms_jabatan.Find(id);
            if (ms_jabatan == null)
            {
                return HttpNotFound();
            }
            return View(ms_jabatan);
        }

        // POST: ms_jabatan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ms_jabatan ms_jabatan = db.ms_jabatan.Find(id);
            db.ms_jabatan.Remove(ms_jabatan);
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
