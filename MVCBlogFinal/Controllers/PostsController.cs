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
using PagedList;

namespace MVCBlogFinal.Controllers
{
   
    public class PostsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author).Include(p => p.Category);

            return View(posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = db.Posts.Find(id);
            IEnumerable<Comment> comments = db.Comments.Where(s => s.PostID == id).ToList();
            if (post == null)
            {
                return HttpNotFound();
            }
            var model = new Tuple<Post, IEnumerable<Comment>>(post, comments);
            return View(model);
        }
        [Authorize]
        // GET: Posts/Create
        public ActionResult Create()
        {
            var authors = db.Authors.AsEnumerable().Select(s => new
            {
                ID = s.ID,
                FirstName = string.Format("{0} {1}", s.FirstName, s.LastName)
            }).ToList();
            ViewBag.AuthorID = new SelectList(authors, "ID", "FirstName");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Title,Content,AuthorID,CategoryID,URL,Likes")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                post.Date = DateTime.Today;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "FirstName", post.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", post.CategoryID);
            return View(post);
        }
        [HttpPost]
        public ActionResult Search(string keyword)
        {
            if (keyword == null)
            {
                return HttpNotFound();
            }else
            {
                IEnumerable<Post> posts = db.Posts.Where(s => s.Title.Contains(keyword) || s.Content.Contains(keyword)).ToList().AsEnumerable();
                return View(posts);
            }
        }



        [Authorize]
        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "FirstName", post.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", post.CategoryID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Title,Content,AuthorID,CategoryID,URL,Likes")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "ID", "FirstName", post.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", post.CategoryID);
            return View(post);
        }

        // GET: Posts/Delete/5 
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Authorize]
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
