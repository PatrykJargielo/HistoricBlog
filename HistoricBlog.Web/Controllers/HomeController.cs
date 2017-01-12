using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HistoricBlog.BLL.Logger;


namespace HistoricBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        public ILoggerService _loggerService;
        
        public ActionResult Index()
        {
            //_loggerService.Error("test");

            //log.Error("Sprawdzenie czy logger w kontrolerze dziala");
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
            //log.Error("Sprawdzenie czy loguje kontakty");
            return View();
        }
    }
}