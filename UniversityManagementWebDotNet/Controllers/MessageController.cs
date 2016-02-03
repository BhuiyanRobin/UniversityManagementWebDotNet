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
    public class MessageController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /Message/
        public ActionResult Index()
        {
            string name = Session["UserName"].ToString();
            var category = db.Logins.FirstOrDefault(a => a.UserName == name);
            var operators = db.Operators.FirstOrDefault( a=>a.Catagory==category.Category);
            var allMessage = db.Messages.Where(a => a.OperatorId == operators.Id).ToList();
            //var messages = db.Messages.Include(m => m.AOperator.Id==operators.Id);
            return View(allMessage);
        }

        // GET: /Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: /Message/Create
        public ActionResult Create()
        {
            ViewBag.OperatorId = new SelectList(db.Operators, "Id", "Catagory");
            return View();
        }

        // POST: /Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,OperatorId,SenderId,Messages")] Message message)
        {
            if (ModelState.IsValid)
            {
                string name=Session["UserName"].ToString();
                message.SenderId = name;
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OperatorId = new SelectList(db.Operators, "Id", "Catagory", message.OperatorId);
            return View(message);
        }

        // GET: /Message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.OperatorId = new SelectList(db.Operators, "Id", "Catagory", message.OperatorId);
            return View(message);
        }

        // POST: /Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,OperatorId,SenderId,Messages")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OperatorId = new SelectList(db.Operators, "Id", "Catagory", message.OperatorId);
            return View(message);
        }

        // GET: /Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: /Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
