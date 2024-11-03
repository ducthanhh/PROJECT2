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
    public class Khach_HangController : Controller
    {
        private QL_BANHANGEntities db = new QL_BANHANGEntities();

        // GET: Khach_Hang
        public ActionResult Index()
        {
            var khach_Hang = db.Khach_Hang.Include(k => k.Don_Hangg);
            return View(khach_Hang.ToList());
        }

        // GET: Khach_Hang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khach_Hang khach_Hang = db.Khach_Hang.Find(id);
            if (khach_Hang == null)
            {
                return HttpNotFound();
            }
            return View(khach_Hang);
        }

        // GET: Khach_Hang/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.Don_Hangg, "MaKH", "MaSP");
            return View();
        }

        // POST: Khach_Hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,Ho_Ten,Tai_Khoan,Mat_Khau,Dia_Chi,Dien_Thoai,Email,Trang_Thai")] Khach_Hang khach_Hang)
        {
            if (ModelState.IsValid)
            {
                db.Khach_Hang.Add(khach_Hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.Don_Hangg, "MaKH", "MaSP", khach_Hang.MaKH);
            return View(khach_Hang);
        }

        // GET: Khach_Hang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khach_Hang khach_Hang = db.Khach_Hang.Find(id);
            if (khach_Hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.Don_Hangg, "MaKH", "MaSP", khach_Hang.MaKH);
            return View(khach_Hang);
        }

        // POST: Khach_Hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,Ho_Ten,Tai_Khoan,Mat_Khau,Dia_Chi,Dien_Thoai,Email,Trang_Thai")] Khach_Hang khach_Hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khach_Hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.Don_Hangg, "MaKH", "MaSP", khach_Hang.MaKH);
            return View(khach_Hang);
        }

        // GET: Khach_Hang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khach_Hang khach_Hang = db.Khach_Hang.Find(id);
            if (khach_Hang == null)
            {
                return HttpNotFound();
            }
            return View(khach_Hang);
        }

        // POST: Khach_Hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Khach_Hang khach_Hang = db.Khach_Hang.Find(id);
            db.Khach_Hang.Remove(khach_Hang);
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
