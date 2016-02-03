using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UniversityManagementWebDotNet.Models.DAO;
using UniversityManagementWebDotNet.Models.Gateway;

namespace UniversityManagementWebDotNet.Controllers
{
    public class LogInController : Controller
    {
        //
        // GET: /LogIn/
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogIn aLogIn)
        {
            //this action is for handle post method
            if (ModelState.IsValid)//this will check validity
            {
                using (Gateway db=new Gateway())
                {
                    var v = db.Logins.FirstOrDefault(a => a.UserName == aLogIn.UserName&&a.Password==aLogIn.Password);
                    if (v!=null&&v.Category=="student")
                    {
                        Session["UserName"] = v.UserName.ToString();
                        return RedirectToAction("StudentAfterLogIn");

                    }
                    else if (v != null && v.Category == "admin")
                    {
                        
                            Session["UserName"] = v.UserName.ToString();
                            return RedirectToAction("AdminAfterLogIn");

                        
                    }
                   
                }
            }
            return View(aLogIn);

        }

        public ActionResult StudentAfterLogIn()
        {
            if (Session["UserName"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
             
            
        }
        public ActionResult AdminAfterLogIn()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home");
            }

        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

       
    }
}