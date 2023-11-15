using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Thi62CNTT12_62130690.Models;

namespace Thi62CNTT12_62130690.Controllers
{
    public class HocVien_62130690Controller : Controller
    {
        private Thi62CNTT12_62130690Entities db = new Thi62CNTT12_62130690Entities();

        // GET: HocVien_62130690
        public ActionResult Index()
        {
            var hocVien = db.HocVien.Include(h => h.DoiTuong);
            return View(hocVien.ToList());
        }
        //Tìm kiếm
        public ActionResult TimKiem()
        {
            var hocViens = db.HocVien.Include(n => n.DoiTuong);
            return View(hocViens.ToList());
        }
        [HttpPost]
        public ActionResult TimKiem(string maHV)
        {

            var hocViens  = db.HocVien.Where(abc => abc.MaHV == maHV);
            return View(hocViens.ToList());
        }
        [HttpGet]

        public ActionResult TimKiem62130690(string hoTen = "", string maDT = "")
        {
            ViewBag.hoTen = hoTen;
            ViewBag.MaDT = new SelectList(db.DoiTuong, "MaDT", "TenDT");
            var hocViens = db.HocVien.SqlQuery("HocVien_TimKiem'" + hoTen + "','" + maDT + "'");
            if (hocViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(hocViens.ToList());
        }
        // GET: HocVien_62130690/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocVien hocVien = db.HocVien.Find(id);
            if (hocVien == null)
            {
                return HttpNotFound();
            }
            return View(hocVien);
        }

        // GET: HocVien_62130690/Create
        public ActionResult Create()
        {
            ViewBag.MaDT = new SelectList(db.DoiTuong, "MaDT", "TenDT");
            return View();
        }

        // POST: HocVien_62130690/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHV,HoSV,TenSV,Anh,NgaySinh,GioiTinh,Email,DiaChi,MaDT")] HocVien hocVien)
        {
            if (ModelState.IsValid)
            {
                db.HocVien.Add(hocVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDT = new SelectList(db.DoiTuong, "MaDT", "TenDT", hocVien.MaDT);
            return View(hocVien);
        }

        // GET: HocVien_62130690/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocVien hocVien = db.HocVien.Find(id);
            if (hocVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDT = new SelectList(db.DoiTuong, "MaDT", "TenDT", hocVien.MaDT);
            return View(hocVien);
        }

        // POST: HocVien_62130690/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHV,HoSV,TenSV,Anh,NgaySinh,GioiTinh,Email,DiaChi,MaDT")] HocVien hocVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDT = new SelectList(db.DoiTuong, "MaDT", "TenDT", hocVien.MaDT);
            return View(hocVien);
        }

        // GET: HocVien_62130690/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocVien hocVien = db.HocVien.Find(id);
            if (hocVien == null)
            {
                return HttpNotFound();
            }
            return View(hocVien);
        }

        // POST: HocVien_62130690/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HocVien hocVien = db.HocVien.Find(id);
            db.HocVien.Remove(hocVien);
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
