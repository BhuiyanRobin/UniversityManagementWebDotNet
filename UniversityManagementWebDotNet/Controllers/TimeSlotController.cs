using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebDotNet.Models.DAO;
using UniversityManagementWebDotNet.Models.Gateway;

namespace UniversityManagementWebDotNet.Controllers
{
    public class TimeSlotController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /TimeSlot/
        public ActionResult Index()
        {
            return View(db.TimeSlots.ToList());
        }

        // GET: /TimeSlot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlot timeslot = db.TimeSlots.Find(id);
            if (timeslot == null)
            {
                return HttpNotFound();
            }
            return View(timeslot);
        }

        // GET: /TimeSlot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TimeSlot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,TimeForm,TimeTo")] TimeSlot timeslot)
        {
            if (ModelState.IsValid)
            {
                db.TimeSlots.Add(timeslot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeslot);
        }

        // GET: /TimeSlot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlot timeslot = db.TimeSlots.Find(id);
            if (timeslot == null)
            {
                return HttpNotFound();
            }
            return View(timeslot);
        }

        // POST: /TimeSlot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,TimeForm,TimeTo")] TimeSlot timeslot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeslot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeslot);
        }

        // GET: /TimeSlot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlot timeslot = db.TimeSlots.Find(id);
            if (timeslot == null)
            {
                return HttpNotFound();
            }
            return View(timeslot);
        }

        // POST: /TimeSlot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSlot timeslot = db.TimeSlots.Find(id);
            db.TimeSlots.Remove(timeslot);
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
