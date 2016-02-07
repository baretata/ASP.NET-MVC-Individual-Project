using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecruitYourselfApplication.Data;

namespace RecruitYourselfApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private RecruitYourselfDbContext db = new RecruitYourselfDbContext();

        public ActionResult Index()
        {
            db.Categories.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}