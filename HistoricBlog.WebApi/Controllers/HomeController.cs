﻿using HistoricBlog.BLL.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HistoricBlog.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ILoggerService LoggerService { get; set; }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
