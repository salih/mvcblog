using MVCBlogFinal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlogFinal.Models;
using PagedList;

namespace MVCBlogFinal.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext db = new BlogContext();
        private SiteSettings settings;
        public HomeController()
        {
            settings = db.SiteSettings.FirstOrDefault();
        }
        public ActionResult Index(int? page)
        {
          IEnumerable<Post> posts = db.Posts.OrderBy(s=>-s.ID).ToList();
            if (settings != null)
            {
                ViewBag.Title = settings.Title;
                ViewBag.Desc = settings.Desc;
                ViewBag.PostPerPage = settings.PostPerPage;
            }else
            {
                ViewBag.Title = "";
                ViewBag.Desc = "";
                ViewBag.PostPerPage = "";
            }
            HomeViewModel homeView = new HomeViewModel();
            int currentPage = (page ?? 1);
            homeView.Posts = posts.ToPagedList(currentPage, db.SiteSettings.First().PostPerPage);
            return View(homeView);
            //var model = new Tuple<IEnumerable<Post>, SiteSettings>(posts, settings);
           // return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Title = settings.Title;
            ViewBag.Desc = settings.Desc;
            ViewBag.About = settings.About;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}