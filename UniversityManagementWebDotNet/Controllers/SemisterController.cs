using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UniversityManagementWebDotNet.Models.DAO;
using UniversityManagementWebDotNet.Models.Gateway;

namespace UniversityManagementWebDotNet.Controllers
{
    public class SemisterController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /Semister/
        public ActionResult Index()
        {
            return View(db.Semisters.ToList());
        }

        // GET: /Semister/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semister semister = db.Semisters.Find(id);
            if (semister == null)
            {
                return HttpNotFound();
            }
            return View(semister);
        }

        // GET: /Semister/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Semister/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Years,SemistereName")] Semister semister)
        {
            if (ModelState.IsValid)
            {
                db.Semisters.Add(semister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semister);
        }

        // GET: /Semister/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semister semister = db.Semisters.Find(id);
            if (semister == null)
            {
                return HttpNotFound();
            }
            return View(semister);
        }

        // POST: /Semister/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Years,SemistereName")] Semister semister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semister);
        }

        // GET: /Semister/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semister semister = db.Semisters.Find(id);
            if (semister == null)
            {
                return HttpNotFound();
            }
            return View(semister);
        }

        // POST: /Semister/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semister semister = db.Semisters.Find(id);
            db.Semisters.Remove(semister);
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
        public ActionResult Home()
        {
            return View();
        }
        
        [ValidateAntiForgeryToken]
        public ActionResult Check(Semister aSemister)
        {
           
            string message;
            if (ModelState.IsValid)
            {
                var check = db.Semisters.FirstOrDefault(p => p.Years == aSemister.Years && p.SemistereName == aSemister.SemistereName);
                if (check == null)
                {
                    using (db)
                    {
                        db.Semisters.Add(aSemister);
                        db.SaveChanges();
                    }
                    message = "";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    message = "Semister are already Entered";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
            }


            return RedirectToAction("Create", "Semister");
        }
    }
}
