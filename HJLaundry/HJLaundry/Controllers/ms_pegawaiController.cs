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
    public class ms_pegawaiController : Controller
    {
        private laundryEntities db = new laundryEntities();

        // GET: ms_pegawai
        public ActionResult Index(string opsi)
        {
            var pgw = from ms_pegawai in db.ms_pegawai select ms_pegawai;

            if (opsi == "1")
            {
                pgw = pgw.Where(ms_pegawai => ms_pegawai.status_pgw == 1);
                ViewBag.aktif = "active";
                ViewBag.nonaktif = "";
            }
            else if (opsi == "0")
            {
                pgw = pgw.Where(ms_pegawai => ms_pegawai.status_pgw == 0);
                ViewBag.aktif = "";
                ViewBag.nonaktif = "active";
            }
            return View(pgw.ToList());
        }

        // GET: ms_pegawai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_pegawai ms_pegawai = db.ms_pegawai.Find(id);
            if (ms_pegawai == null)
            {
                return HttpNotFound();
            }
            return View(ms_pegawai);
        }

        // GET: ms_pegawai/Create
        public ActionResult Create()
        {
            ViewBag.id_jabatan = new SelectList(db.ms_jabatan, "id_jabatan", "nama_jabatan");
            return View();
        }

        // POST: ms_pegawai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pegawai,nama_pegawai,tgl_lahir,jenis_kelamin,telp_pegawai,alamat_pegawai,id_jabatan,username,password,status_pgw")] ms_pegawai ms_pegawai)
        {
            if (ModelState.IsValid)
            {
                ms_pegawai.status_pgw = 1;
                db.ms_pegawai.Add(ms_pegawai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_jabatan = new SelectList(db.ms_jabatan, "id_jabatan", "nama_jabatan", ms_pegawai.id_jabatan);
            return View(ms_pegawai);
        }

        // GET: ms_pegawai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_pegawai ms_pegawai = db.ms_pegawai.Find(id);
            if (ms_pegawai == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_jabatan = new SelectList(db.ms_jabatan, "id_jabatan", "nama_jabatan", ms_pegawai.id_jabatan);
            return View(ms_pegawai);
        }

        // POST: ms_pegawai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pegawai,nama_pegawai,tgl_lahir,jenis_kelamin,telp_pegawai,alamat_pegawai,id_jabatan,username,password,status_pgw")] ms_pegawai ms_pegawai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ms_pegawai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_jabatan = new SelectList(db.ms_jabatan, "id_jabatan", "nama_jabatan", ms_pegawai.id_jabatan);
            return View(ms_pegawai);
        }

        // GET: ms_pegawai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ms_pegawai ms_pegawai = db.ms_pegawai.Find(id);
            if (ms_pegawai == null)
            {
                return HttpNotFound();
            }
            return View(ms_pegawai);
        }

        // POST: ms_pegawai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ms_pegawai ms_pegawai = db.ms_pegawai.Find(id);
            ms_pegawai.status_pgw = 0;
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
