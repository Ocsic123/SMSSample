using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NEWIMSApplication.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index()
        //{
        //    return View();
        //}

        //public ContentResult Index()
        //{
        //    return Content("<h3>Hi This is ASP.NET </h3>");
        //}

        //public EmptyResult Index()
        //{
        //    return new EmptyResult();
        //}

        //public FileResult Index()
        //{
        //    return File("~/App_Data/a.txt", "text/plain");
        //}

        //public FileResult Index()
        //{
        //    return File(Url.Content("~/App_Data/a.txt"), "text/plain", "testFile.txt");
        //}

        //public JsonResult Index()
        //{
        //    return Json(new { Name = "Zain Ul Hassan", ID = 1 });
        //}


        //public JsonResult Index()
        //{
        //    return Json(new { Name = "Zain Ul Hassan", ID = 1 }, JsonRequestBehavior.AllowGet);
        //}

        public HttpStatusCodeResult Index()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
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