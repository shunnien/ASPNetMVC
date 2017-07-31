using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelExt.Models;
using ModelExt.Utility;
using ModelExt.ViewModels;

namespace ModelExt.Controllers
{
    public class Order_DetailsController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Order_Details
        public ActionResult Index()
        {
            //var order_Details = db.Order_Details.Include(o => o.Orders);
            var order_Details = db.Order_Details.ToList().Select(o=> new OrderDetailViewModel()
            {
                OrderID = o.OrderID,
                ProductID = o.ProductID,
                UnitPrice = o.UnitPrice,
                Quantity = o.Quantity,
                Discount = o.Discount,
                TotalPrice = o.TotalPrice()
            });
            return View(order_Details);
        }

        // GET: Order_Details/Details/5
        public ActionResult Details(int? OrderID, int? ProductID)
        {
            if (OrderID == null || ProductID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = db.Order_Details.Find(OrderID, ProductID);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            return View(order_Details);
        }

        // GET: Order_Details/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID");
            return View();
        }

        // POST: Order_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ProductID,UnitPrice,Quantity,Discount")] Order_Details order_Details)
        {
            if (ModelState.IsValid)
            {
                db.Order_Details.Add(order_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", order_Details.OrderID);
            return View(order_Details);
        }

        // GET: Order_Details/Edit/5
        public ActionResult Edit(int? OrderID, int? ProductID)
        {
            if (OrderID == null || ProductID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = db.Order_Details.Find(OrderID, ProductID);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", order_Details.OrderID);
            return View(order_Details);
        }

        // POST: Order_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ProductID,UnitPrice,Quantity,Discount")] Order_Details order_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", order_Details.OrderID);
            return View(order_Details);
        }

        // GET: Order_Details/Delete/5
        public ActionResult Delete(int? OrderID, int? ProductID)
        {
            if (OrderID == null || ProductID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = db.Order_Details.Find(OrderID, ProductID);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            return View(order_Details);
        }

        // POST: Order_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Details order_Details = db.Order_Details.Find(id);
            db.Order_Details.Remove(order_Details);
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
