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
    public class CourseAssignController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /CourseAssign/
        public ActionResult Index()
        {
            var courseassigns = db.CourseAssigns.Include(c => c.ACourse).Include(c => c.AFaculty).Include(c => c.ARoom).Include(c => c.ASemister).Include(c => c.ATimeSlot).Include(c => c.AWeekDaysS);
            return View(courseassigns.ToList());
        }

        // GET: /CourseAssign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // GET: /CourseAssign/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode");
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "FacultyCode");
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomNumber");
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "SemistereName");
            ViewBag.TimeSlotId = new SelectList(db.TimeSlots, "Id", "Id");
            ViewBag.WeekDaysId = new SelectList(db.Dayses, "Id", "Code");
            return View();
        }

        // POST: /CourseAssign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,SemisterId,CourseId,Section,TimeSlotId,WeekDaysId,RoomId,FacultyId")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssigns.Add(courseassign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", courseassign.CourseId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "FacultyName", courseassign.FacultyId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomName", courseassign.RoomId);
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "SemistereName", courseassign.SemisterId);
            ViewBag.TimeSlotId = new SelectList(db.TimeSlots, "Id", "Id", courseassign.TimeSlotId);
            ViewBag.WeekDaysId = new SelectList(db.Dayses, "Id", "Name", courseassign.WeekDaysId);
            return View(courseassign);
        }

        // GET: /CourseAssign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", courseassign.CourseId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "FacultyName", courseassign.FacultyId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomName", courseassign.RoomId);
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "SemistereName", courseassign.SemisterId);
            ViewBag.TimeSlotId = new SelectList(db.TimeSlots, "Id", "Id", courseassign.TimeSlotId);
            ViewBag.WeekDaysId = new SelectList(db.Dayses, "Id", "Name", courseassign.WeekDaysId);
            return View(courseassign);
        }

        // POST: /CourseAssign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,SemisterId,CourseId,Section,TimeSlotId,WeekDaysId,RoomId,FacultyId")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseassign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", courseassign.CourseId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "FacultyName", courseassign.FacultyId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomName", courseassign.RoomId);
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "SemistereName", courseassign.SemisterId);
            ViewBag.TimeSlotId = new SelectList(db.TimeSlots, "Id", "Id", courseassign.TimeSlotId);
            ViewBag.WeekDaysId = new SelectList(db.Dayses, "Id", "Name", courseassign.WeekDaysId);
            return View(courseassign);
        }

        // GET: /CourseAssign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // POST: /CourseAssign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            db.CourseAssigns.Remove(courseassign);
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

        public ActionResult AllTimeSlot()
        {
            var timeSlot = db.TimeSlots;
            List<Time>times=new List<Time>();
            foreach (TimeSlot slot in timeSlot)
            {

                Time aTime=new Time();
                aTime.Id = slot.Id;
                aTime.Slot = slot.TimeForm + "-" + slot.TimeTo;
                times.Add(aTime);
            }

            return Json(times, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllSemister()
        {
            var allsem = db.Semisters;
            List<Semiste>semistes=new List<Semiste>();
            foreach (Semister semiste in allsem)
            {
               Semiste aSemiste=new Semiste();
                aSemiste.Id =semiste.Id ;
                aSemiste.Name = semiste.SemistereName +"-"+ semiste.Years;
                semistes.Add(aSemiste);
            }
            return Json(semistes, JsonRequestBehavior.AllowGet);
        }
    }

    internal class Semiste
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
    internal class Time
    {
        public int Id { set; get; }
        public string Slot { set; get; }
    }
}
