using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using banhang.Models;

namespace banhang.Controllers
{
    public class Don_HanggController : Controller
    {
        private QL_BANHANGEntities db = new QL_BANHANGEntities();

        // GET: Don_Hangg
        public ActionResult Index()
        {
            var don_Hangg = db.Don_Hangg.Include(d => d.Danhmuc_SP).Include(d => d.Khach_Hang);
            return View(don_Hangg.ToList());
        }

        // GET: Don_Hangg/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Don_Hangg don_Hangg = db.Don_Hangg.Find(id);
            if (don_Hangg == null)
            {
                return HttpNotFound();
            }
            return View(don_Hangg);
        }

        // GET: Don_Hangg/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.Danhmuc_SP, "MaSP", "Ten_SP");
            ViewBag.MaKH = new SelectList(db.Khach_Hang, "MaKH", "Ho_Ten");
            return View();
        }

        // POST: Don_Hangg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,MaSP,Don_Gia,Ngay_Dat,Trang_Thai")] Don_Hangg don_Hangg)
        {
            if (ModelState.IsValid)
            {
                db.Don_Hangg.Add(don_Hangg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.Danhmuc_SP, "MaSP", "Ten_SP", don_Hangg.MaSP);
            ViewBag.MaKH = new SelectList(db.Khach_Hang, "MaKH", "Ho_Ten", don_Hangg.MaKH);
            return View(don_Hangg);
        }

        // GET: Don_Hangg/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Don_Hangg don_Hangg = db.Don_Hangg.Find(id);
            if (don_Hangg == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.Danhmuc_SP, "MaSP", "Ten_SP", don_Hangg.MaSP);
            ViewBag.MaKH = new SelectList(db.Khach_Hang, "MaKH", "Ho_Ten", don_Hangg.MaKH);
            return View(don_Hangg);
        }

        // POST: Don_Hangg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,MaSP,Don_Gia,Ngay_Dat,Trang_Thai")] Don_Hangg don_Hangg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(don_Hangg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.Danhmuc_SP, "MaSP", "Ten_SP", don_Hangg.MaSP);
            ViewBag.MaKH = new SelectList(db.Khach_Hang, "MaKH", "Ho_Ten", don_Hangg.MaKH);
            return View(don_Hangg);
        }

        // GET: Don_Hangg/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Don_Hangg don_Hangg = db.Don_Hangg.Find(id);
            if (don_Hangg == null)
            {
                return HttpNotFound();
            }
            return View(don_Hangg);
        }

        // POST: Don_Hangg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Don_Hangg don_Hangg = db.Don_Hangg.Find(id);
            db.Don_Hangg.Remove(don_Hangg);
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
