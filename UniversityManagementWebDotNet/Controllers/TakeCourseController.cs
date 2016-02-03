using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebDotNet.Migrations;
using UniversityManagementWebDotNet.Models.DAO;
using UniversityManagementWebDotNet.Models.Gateway;

namespace UniversityManagementWebDotNet.Controllers
{
    public class TakeCourseController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /TakeCourse/
        public ActionResult Index()
        {
            var takecourses = db.TakeCourses.Include(t => t.ACourse).Include(t => t.ASemister);
            return View(takecourses.ToList());
        }

        // GET: /TakeCourse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TakeCourse takecourse = db.TakeCourses.Find(id);
            if (takecourse == null)
            {
                return HttpNotFound();
            }
            return View(takecourse);
        }

        // GET: /TakeCourse/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode");
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "SemistereName");
            return View();
        }

        // POST: /TakeCourse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,SemisterId,StudentId,CourseId,Section")] TakeCourse takecourse)
        {
            if (ModelState.IsValid)
            {
                db.TakeCourses.Add(takecourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", takecourse.CourseId);
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "SemistereName", takecourse.SemisterId);
            return View(takecourse);
        }

        // GET: /TakeCourse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TakeCourse takecourse = db.TakeCourses.Find(id);
            if (takecourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", takecourse.CourseId);
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "SemistereName", takecourse.SemisterId);
            return View(takecourse);
        }

        // POST: /TakeCourse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,SemisterId,StudentId,CourseId,Section")] TakeCourse takecourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(takecourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", takecourse.CourseId);
            ViewBag.SemisterId = new SelectList(db.Semisters, "Id", "SemistereName", takecourse.SemisterId);
            return View(takecourse);
        }

        // GET: /TakeCourse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TakeCourse takecourse = db.TakeCourses.Find(id);
            if (takecourse == null)
            {
                return HttpNotFound();
            }
            return View(takecourse);
        }

        // POST: /TakeCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TakeCourse takecourse = db.TakeCourses.Find(id);
            db.TakeCourses.Remove(takecourse);
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
        public ActionResult FindThisCourse(int courseId)
        {

            var courses = db.CourseAssigns.Where(x => x.CourseId == courseId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TakenCourseInformation(TakeCourse course)
        {
            
          var information = db.CourseAssigns.FirstOrDefault(x=>x.Section==course.Section&&x.CourseId==course.CourseId&&x.SemisterId==course.SemisterId);
            var aCourse = db.Courses.FirstOrDefault(x => x.Id == information.CourseId);
            var aTimeSlot = db.TimeSlots.FirstOrDefault(x => x.Id == information.CourseId);
            var aRoom = db.Rooms.FirstOrDefault(x => x.Id == information.RoomId);
            var aWeekday = db.Dayses.FirstOrDefault(x => x.Id == information.WeekDaysId);
            var timeSlot = aTimeSlot.TimeForm + "-" + aTimeSlot.TimeTo;
            AllInformation allInformation=new AllInformation();

            allInformation.CourseCode = aCourse.CourseCode;
            allInformation.CourseTime = timeSlot;
            allInformation.Section = information.Section;
            allInformation.Credit = aCourse.CourseCredit;
            allInformation.Amount = 11400.00;
            allInformation.DayCoed = aWeekday.Code;
            allInformation.RoomNumber = aRoom.RoomNumber;

            db.TakeCourses.AddOrUpdate(course);
            db.SaveChanges();
            return Json(allInformation, JsonRequestBehavior.AllowGet);
        }
    }

    internal class AllInformation
    {
        public string CourseCode { set; get; }
        public int Section { set; get; }
        public double Credit { set; get; }
        public double Amount { set; get; }
        public string CourseTime { set; get; }
        public string DayCoed { set; get; }
        public string RoomNumber { set; get; }
    }
}
