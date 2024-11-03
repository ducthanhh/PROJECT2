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
    public class Danhmuc_SPController : Controller
    {
        private QL_BANHANGEntities db = new QL_BANHANGEntities();

        // GET: Danhmuc_SP
        public ActionResult Index()
        {
            var danhmuc_SP = db.Danhmuc_SP.Include(d => d.San_Pham);
            return View(danhmuc_SP.ToList());
        }

        // GET: Danhmuc_SP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc_SP danhmuc_SP = db.Danhmuc_SP.Find(id);
            if (danhmuc_SP == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc_SP);
        }

        // GET: Danhmuc_SP/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.San_Pham, "MaSP", "Ten_SP");
            return View();
        }

        // POST: Danhmuc_SP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,Ten_SP,Gia_SP")] Danhmuc_SP danhmuc_SP)
        {
            if (ModelState.IsValid)
            {
                db.Danhmuc_SP.Add(danhmuc_SP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.San_Pham, "MaSP", "Ten_SP", danhmuc_SP.MaSP);
            return View(danhmuc_SP);
        }

        // GET: Danhmuc_SP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc_SP danhmuc_SP = db.Danhmuc_SP.Find(id);
            if (danhmuc_SP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.San_Pham, "MaSP", "Ten_SP", danhmuc_SP.MaSP);
            return View(danhmuc_SP);
        }

        // POST: Danhmuc_SP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,Ten_SP,Gia_SP")] Danhmuc_SP danhmuc_SP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmuc_SP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.San_Pham, "MaSP", "Ten_SP", danhmuc_SP.MaSP);
            return View(danhmuc_SP);
        }

        // GET: Danhmuc_SP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Danhmuc_SP danhmuc_SP = db.Danhmuc_SP.Find(id);
            if (danhmuc_SP == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc_SP);
        }

        // POST: Danhmuc_SP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Danhmuc_SP danhmuc_SP = db.Danhmuc_SP.Find(id);
            db.Danhmuc_SP.Remove(danhmuc_SP);
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
