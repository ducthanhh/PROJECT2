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
    public class Quan_TriController : Controller
    {
        private QL_BANHANGEntities db = new QL_BANHANGEntities();

        // GET: Quan_Tri
        public ActionResult Index()
        {
            return View(db.Quan_Tri.ToList());
        }

        // GET: Quan_Tri/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quan_Tri quan_Tri = db.Quan_Tri.Find(id);
            if (quan_Tri == null)
            {
                return HttpNotFound();
            }
            return View(quan_Tri);
        }

        // GET: Quan_Tri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quan_Tri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tai_Khoan,Mat_Khau,Trang_Thai")] Quan_Tri quan_Tri)
        {
            if (ModelState.IsValid)
            {
                db.Quan_Tri.Add(quan_Tri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quan_Tri);
        }

        // GET: Quan_Tri/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quan_Tri quan_Tri = db.Quan_Tri.Find(id);
            if (quan_Tri == null)
            {
                return HttpNotFound();
            }
            return View(quan_Tri);
        }

        // POST: Quan_Tri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tai_Khoan,Mat_Khau,Trang_Thai")] Quan_Tri quan_Tri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quan_Tri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quan_Tri);
        }

        // GET: Quan_Tri/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quan_Tri quan_Tri = db.Quan_Tri.Find(id);
            if (quan_Tri == null)
            {
                return HttpNotFound();
            }
            return View(quan_Tri);
        }

        // POST: Quan_Tri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Quan_Tri quan_Tri = db.Quan_Tri.Find(id);
            db.Quan_Tri.Remove(quan_Tri);
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
