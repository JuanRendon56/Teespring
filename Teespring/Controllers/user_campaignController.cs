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
    public class user_campaignController : Controller
    {
        private TeespringDBEntities2 db = new TeespringDBEntities2();

        // GET: user_campaign
        public ActionResult Index()
        {
            var user_campaign = db.user_campaign.Include(u => u.campaign).Include(u => u.user);
            return View(user_campaign.ToList());
        }

        // GET: user_campaign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_campaign user_campaign = db.user_campaign.Find(id);
            if (user_campaign == null)
            {
                return HttpNotFound();
            }
            return View(user_campaign);
        }

        // GET: user_campaign/Create
        public ActionResult Create()
        {
            ViewBag.id_campaign = new SelectList(db.campaigns, "id_campaign", "title");
            ViewBag.id_user = new SelectList(db.users, "id_user", "email");
            return View();
        }

        // POST: user_campaign/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_user,id_campaign")] user_campaign user_campaign)
        {
            if (ModelState.IsValid)
            {
                db.user_campaign.Add(user_campaign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_campaign = new SelectList(db.campaigns, "id_campaign", "title", user_campaign.id_campaign);
            ViewBag.id_user = new SelectList(db.users, "id_user", "email", user_campaign.id_user);
            return View(user_campaign);
        }

        // GET: user_campaign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_campaign user_campaign = db.user_campaign.Find(id);
            if (user_campaign == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_campaign = new SelectList(db.campaigns, "id_campaign", "title", user_campaign.id_campaign);
            ViewBag.id_user = new SelectList(db.users, "id_user", "email", user_campaign.id_user);
            return View(user_campaign);
        }

        // POST: user_campaign/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_user,id_campaign")] user_campaign user_campaign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_campaign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_campaign = new SelectList(db.campaigns, "id_campaign", "title", user_campaign.id_campaign);
            ViewBag.id_user = new SelectList(db.users, "id_user", "email", user_campaign.id_user);
            return View(user_campaign);
        }

        // GET: user_campaign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_campaign user_campaign = db.user_campaign.Find(id);
            if (user_campaign == null)
            {
                return HttpNotFound();
            }
            return View(user_campaign);
        }

        // POST: user_campaign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_campaign user_campaign = db.user_campaign.Find(id);
            db.user_campaign.Remove(user_campaign);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
