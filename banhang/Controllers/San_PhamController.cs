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
    public class San_PhamController : Controller
    {
        private QL_BANHANGEntities db = new QL_BANHANGEntities();

        // GET: San_Pham
        public ActionResult Index()
        {
            var san_Pham = db.San_Pham.Include(s => s.Danhmuc_SP);
            return View(san_Pham.ToList());
        }

        // GET: San_Pham/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            San_Pham san_Pham = db.San_Pham.Find(id);
            if (san_Pham == null)
            {
                return HttpNotFound();
            }
            return View(san_Pham);
        }

        // GET: San_Pham/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.Danhmuc_SP, "MaSP", "Ten_SP");
            return View();
        }

        // POST: San_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,Ten_SP,Loai_SP,Nam_SX,Trang_Thai")] San_Pham san_Pham)
        {
            if (ModelState.IsValid)
            {
                db.San_Pham.Add(san_Pham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.Danhmuc_SP, "MaSP", "Ten_SP", san_Pham.MaSP);
            return View(san_Pham);
        }

        // GET: San_Pham/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            San_Pham san_Pham = db.San_Pham.Find(id);
            if (san_Pham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.Danhmuc_SP, "MaSP", "Ten_SP", san_Pham.MaSP);
            return View(san_Pham);
        }

        // POST: San_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,Ten_SP,Loai_SP,Nam_SX,Trang_Thai")] San_Pham san_Pham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(san_Pham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.Danhmuc_SP, "MaSP", "Ten_SP", san_Pham.MaSP);
            return View(san_Pham);
        }

        // GET: San_Pham/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            San_Pham san_Pham = db.San_Pham.Find(id);
            if (san_Pham == null)
            {
                return HttpNotFound();
            }
            return View(san_Pham);
        }

        // POST: San_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            San_Pham san_Pham = db.San_Pham.Find(id);
            db.San_Pham.Remove(san_Pham);
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
