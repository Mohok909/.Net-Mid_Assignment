using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mid_Assignment.Models;

namespace Mid_Assignment.Controllers
{
    public class FoodRequestsController : Controller
    {
        private DatabaseConn db = new DatabaseConn();

        // GET: FoodRequests
        public ActionResult Index()
        {
            var foodRequests = db.FoodRequests.Include(f => f.Shop);
            return View(foodRequests.ToList());
        }

        // GET: FoodRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodRequest foodRequest = db.FoodRequests.Find(id);
            if (foodRequest == null)
            {
                return HttpNotFound();
            }
            return View(foodRequest);
        }

        // GET: FoodRequests/Create
        public ActionResult Create()
        {
            ViewBag.ShopId = new SelectList(db.Shops, "Id", "Name");
            return View();
        }

        // POST: FoodRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PerservationTime,Collected,ShopId")] FoodRequest foodRequest)
        {
            if (ModelState.IsValid)
            {
                db.FoodRequests.Add(foodRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShopId = new SelectList(db.Shops, "Id", "Name", foodRequest.ShopId);
            return View(foodRequest);
        }

        // GET: FoodRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodRequest foodRequest = db.FoodRequests.Find(id);
            if (foodRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShopId = new SelectList(db.Shops, "Id", "Name", foodRequest.ShopId);
            return View(foodRequest);
        }

        // POST: FoodRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PerservationTime,Collected,ShopId")] FoodRequest foodRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShopId = new SelectList(db.Shops, "Id", "Name", foodRequest.ShopId);
            return View(foodRequest);
        }

        // GET: FoodRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodRequest foodRequest = db.FoodRequests.Find(id);
            if (foodRequest == null)
            {
                return HttpNotFound();
            }
            return View(foodRequest);
        }

        // POST: FoodRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodRequest foodRequest = db.FoodRequests.Find(id);
            db.FoodRequests.Remove(foodRequest);
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
