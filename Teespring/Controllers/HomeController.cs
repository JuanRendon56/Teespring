using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teespring.Models;

namespace Teespring.Controllers
{
  
    public class HomeController : Controller
    {  
        private TeespringDBEntities2 db = new TeespringDBEntities2();
        public ActionResult Index()
        {
            return View(db.campaigns.ToList());
        }
    }
}