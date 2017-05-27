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
    public class AuthorInfoesController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: AuthorInfoes
        public ActionResult Index()
        {
            return View(db.Authors.ToList());
        }

        // GET: AuthorInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorInfo authorInfo = db.Authors.Find(id);
            if (authorInfo == null)
            {
                return HttpNotFound();
            }
            IEnumerable<Post> post = db.Posts.Where(s => s.AuthorID == authorInfo.ID).AsEnumerable();
            var model = new Tuple<IEnumerable<Post>, AuthorInfo>(post, authorInfo);
            return View(model);
        }
        [Authorize]

        // GET: AuthorInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName")] AuthorInfo authorInfo)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(authorInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorInfo);
        }
        [Authorize]

        // GET: AuthorInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorInfo authorInfo = db.Authors.Find(id);
            if (authorInfo == null)
            {
                return HttpNotFound();
            }
            return View(authorInfo);
        }
        [Authorize]

        // POST: AuthorInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName")] AuthorInfo authorInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorInfo);
        }
        [Authorize]

        // GET: AuthorInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorInfo authorInfo = db.Authors.Find(id);
            if (authorInfo == null)
            {
                return HttpNotFound();
            }
            return View(authorInfo);
        }
        [Authorize]

        // POST: AuthorInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorInfo authorInfo = db.Authors.Find(id);
            db.Authors.Remove(authorInfo);
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
