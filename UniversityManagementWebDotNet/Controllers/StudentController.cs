using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebDotNet.Models.DAO;
using UniversityManagementWebDotNet.Models.Gateway;

namespace UniversityManagementWebDotNet.Controllers
{
    public class StudentController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /Student/
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(
                Include =
                    "Id,UniId,Name,Nickname,Password,SscRegistration,SscPassingYear,SscBoard,SscResult,HscRegistration,HscPassingYear,HscBoard,HscResult,FathersVoterId,FathersName,FathersDegignation,FathersContactNumber,FathersEmail,MothersVoterId,MothersName,MothersDegignation,MothersContactNumber,MothersEmail,File"
                )] Student student)
        {
            
            if (ModelState.IsValid)
            {
                if (student.File.ContentLength > 0)
                {
                   var path = Path.Combine(Server.MapPath("~/Image/Student"), student.UniId+".jpg");
                    student.File.SaveAs(path);
                    
                }
                LogIn aLogIn=new LogIn();
                aLogIn.UserName = student.UniId;
                aLogIn.Password = student.Password;
                aLogIn.Category = "student";
                student.File = null;
                db.Students.Add(student);
                db.Logins.AddOrUpdate(aLogIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                Include =
                    "Id,UniId,Name,Nickname,Password,SscRegistration,SscPassingYear,SscBoard,SscResult,HscRegistration,HscPassingYear,HscBoard,HscResult,FathersVoterId,FathersName,FathersDegignation,FathersContactNumber,FathersEmail,MothersVoterId,MothersName,MothersDegignation,MothersContactNumber,MothersEmail,File"
                )] Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.File.ContentLength > 0)
                {
                   
                    
                }
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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

        //public ActionResult PictureUpload(Picture picture, string id)
        //{
        //    string message = "";
        //    if (picture.File.ContentLength > 0)
        //    {
        //        var path = Path.Combine(Server.MapPath("~/Image/Student"), id);
        //        picture.File.SaveAs(path);
        //        message = "Upload Completed";
        //    }
        //    else
        //    {
        //        message = "Upload Is UnFinished";
        //    }

        //    return Json(message, JsonRequestBehavior.AllowGet);
        //}
    }
}
