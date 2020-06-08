using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogManagement.Models;
using Microsoft.AspNet.Identity;

namespace BlogManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var dbContent = new ApplicationDbContext();
            var blogList = dbContent.Blog.Include(x => x.ApplicationUser).Where(d => d.IsActive).OrderByDescending(d => d.CreateDate).Take(3).ToList();
            return View(blogList);
        }
        public ActionResult Detail(int id)
        {
            var dbcontent = new ApplicationDbContext();
            var model = dbcontent.Blog.Include(d=>d.ApplicationUser).FirstOrDefault(d => d.IsActive && d.Id == id);
            return View(model);
        }
        public ActionResult Blogs()
        {
            var dbContent = new ApplicationDbContext();
            var blogList = dbContent.Blog.Include(x=>x.ApplicationUser).Where(d => d.IsActive).OrderByDescending(d => d.CreateDate).ToList();
            return View(blogList);
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect("/home");
        }
    }
}