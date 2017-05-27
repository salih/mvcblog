using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBlogFinal.DAL;
using MVCBlogFinal.Models;

namespace MVCBlogFinal.Controllers
{
    public class SiteSettingsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: SiteSettings
        public ActionResult Index()
        {
            return View(db.SiteSettings.ToList());
        }

        // GET: SiteSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSettings siteSettings = db.SiteSettings.Find(id);
            if (siteSettings == null)
            {
                return HttpNotFound();
            }
            return View(siteSettings);
        }

        // GET: SiteSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Desc,About,PostPerPage")] SiteSettings siteSettings)
        {
            if (ModelState.IsValid)
            {
                db.SiteSettings.Add(siteSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteSettings);
        }

        // GET: SiteSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSettings siteSettings = db.SiteSettings.Find(id);
            if (siteSettings == null)
            {
                return HttpNotFound();
            }
            return PartialView(siteSettings);
        }

        // POST: SiteSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Desc,About,PostPerPage")] SiteSettings siteSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteSettings).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView(siteSettings);
            }
            return View(siteSettings);
        }

        // GET: SiteSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSettings siteSettings = db.SiteSettings.Find(id);
            if (siteSettings == null)
            {
                return HttpNotFound();
            }
            return View(siteSettings);
        }

        // POST: SiteSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteSettings siteSettings = db.SiteSettings.Find(id);
            db.SiteSettings.Remove(siteSettings);
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
