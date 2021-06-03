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
    public class campaignsController : Controller
    {
        private TeespringDBEntities2 db = new TeespringDBEntities2();

        // GET: campaigns
        public ActionResult Index()
        {
            return View(db.campaigns.ToList());
        }

        // GET: campaigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            campaign campaign = db.campaigns.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // GET: campaigns/Share
        public ActionResult Share(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            campaign campaign = db.campaigns.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
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
            }

            if (campaign.id_campaign == 0)
            {
                int id = db.campaigns.Max(m => m.id_campaign);
                campaign.id_campaign = id + 1;
                db.campaigns.Add(campaign);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: campaigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            campaign campaign = db.campaigns.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // POST: campaigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_campaign,title,description,link,created,expiration_date,price")] campaign campaign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campaign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campaign);
        }

        // GET: campaigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            campaign campaign = db.campaigns.Find(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        // POST: campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            campaign campaign = db.campaigns.Find(id);
            db.campaigns.Remove(campaign);
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
