using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HastaTakip.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context C = new Context();             
            var adminuserinfo = C.Admins.FirstOrDefault(x => x.AdminUsername == p.AdminUsername && x.AdminPassword == p.AdminPassword);
            if (adminuserinfo!= null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUsername, false);
                Session["AdminUsername"] = adminuserinfo.AdminUsername;
                return RedirectToAction("Index", "AdminPatient");
            }
            else 
            {
                return RedirectToAction("Index");
            }
 
        }

        [HttpGet]
        public ActionResult DoctorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoctorLogin(Doctor p)
        {
            Context C = new Context();
            var doctoruserinfo = C.Doctors.FirstOrDefault(x => x.DoktorMail == p.DoktorMail && x.DoktorSifre == p.DoktorSifre);
            

            if (doctoruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(doctoruserinfo.DoktorMail, false);
                Session["DoctorMail"] = doctoruserinfo.DoktorMail;
                Session["ad"] = doctoruserinfo.Ad +" "+doctoruserinfo.Soyad;
                return RedirectToAction("MyPatient", "DoctorPanel");
            }
            else
            {
                return RedirectToAction("DoctorLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("DoctorLogin");
        }
    }
}