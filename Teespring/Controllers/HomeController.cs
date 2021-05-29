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

        // GET: campaigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: campaigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_campaign,title,description,link,created,expiration_date,price")] campaign campaign)
        {
            if (ModelState.IsValid)
            {
                db.campaigns.Add(campaign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campaign);
        }
    }
}