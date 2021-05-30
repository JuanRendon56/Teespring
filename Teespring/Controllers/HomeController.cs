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
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user objUser)
        {
            if (ModelState.IsValid)
            {
                using (TeespringDBEntities2 db = new TeespringDBEntities2())
                {
                    var obj = db.users.Where(a => a.email.Equals(objUser.email) && a.password.Equals(objUser.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id_user.ToString();
                        Session["UserName"] = obj.firstname.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
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