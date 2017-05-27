using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCBlogFinal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "PostNew",
              url: "Post/New",
              defaults: new { controller = "Posts", action = "Create" }
              );
            routes.MapRoute(
                name: "Authors",
                url: "Author/",
                defaults: new {controller = "AuthorInfoes", action="Index", id= UrlParameter.Optional} 
                );
            routes.MapRoute(
                name: "AuthorsCreate",
                url: "Author/Create",
                defaults: new { controller = "AuthorInfoes", action = "Create", id = UrlParameter.Optional }
                );
            routes.MapRoute(
              name: "AuthorsEdit",
              url: "Author/Edit",
              defaults: new { controller = "AuthorInfoes", action = "Edit", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "AuthorsDelete",
              url: "Author/Delete",
              defaults: new { controller = "AuthorInfoes", action = "Delete", id = UrlParameter.Optional }
              );
            routes.MapRoute(
                name: "PostView",
                url: "Post/{id}",
                defaults: new { controller = "Posts", action = "Details", id = UrlParameter.Optional }
                );
            routes.MapRoute(
              name: "AuthorDetail",
              url: "Author/{id}",
              defaults: new { controller = "AuthorInfoes", action = "Details", id = UrlParameter.Optional }
              );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
         
          
        }
    }
}
