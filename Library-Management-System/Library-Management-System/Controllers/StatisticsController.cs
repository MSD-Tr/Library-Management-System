﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Weather()
        {
            return View();  
        }
        public ActionResult WeatherCard()
        {
            return View();  
        }

    }
}