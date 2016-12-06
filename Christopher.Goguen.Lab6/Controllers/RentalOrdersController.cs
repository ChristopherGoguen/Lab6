using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Christopher.Goguen.Lab6.Models;

namespace Christopher.Goguen.Lab6.Controllers
{
    public class RentalOrdersController : Controller
    {
        private SheridanSystem db = new SheridanSystem();

        // GET: RentalOrders
        public ActionResult Index()
        {
            var rentalOrders = db.RentalOrders.Include(r => r.Employee);
            return View(rentalOrders.ToList());
        }

        // GET: RentalOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            if (rentalOrder == null)
            {
                return HttpNotFound();
            }
            return View(rentalOrder);
        }

        // GET: RentalOrders/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeEmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName");
            return View();
        }

        // POST: RentalOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalOrderId,CheckoutDate,UniqueId,EmployeeEmployeeId,ReturnDate")] RentalOrder rentalOrder)
        {
            if (ModelState.IsValid)
            {
                db.RentalOrders.Add(rentalOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeEmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", rentalOrder.EmployeeEmployeeId);
            return View(rentalOrder);
        }

        // GET: RentalOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            if (rentalOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeEmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", rentalOrder.EmployeeEmployeeId);
            return View(rentalOrder);
        }

        // POST: RentalOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalOrderId,CheckoutDate,UniqueId,EmployeeEmployeeId,ReturnDate")] RentalOrder rentalOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeEmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", rentalOrder.EmployeeEmployeeId);
            return View(rentalOrder);
        }

        // GET: RentalOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            if (rentalOrder == null)
            {
                return HttpNotFound();
            }
            return View(rentalOrder);
        }

        // POST: RentalOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalOrder rentalOrder = db.RentalOrders.Find(id);
            db.RentalOrders.Remove(rentalOrder);
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
