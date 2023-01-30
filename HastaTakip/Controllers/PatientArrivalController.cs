using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using HastaTakip.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HastaTakip.Controllers
{
    public class PatientArrivalController : Controller
    {
        PatientArrivalManager pam = new PatientArrivalManager(new EfPatientArrivalDal());
        PatientManager pm = new PatientManager(new EfPatientDal());
        DoctorManager dm = new DoctorManager(new EfDoctorDal());

        public ActionResult Index(int p = 1)
        {
            var PatientArrivalValues = pam.GetList().ToPagedList(p, 6); ;
            return View(PatientArrivalValues);
        }

        [HttpGet]
        public ActionResult AddPatientArrival(int id)
        {
            Context db = new Context();
            ViewBag.Servisler = db.Services.ToList().Select(x => new SelectListItem { Text = x.ServisAdi, Value = x.ServisID.ToString() }).ToList();
            ViewBag.Doktorlar = db.Doctors.ToList().Select(x => new SelectListItem { Text = x.Ad + " " + x.Soyad, Value = x.DoktorID.ToString() }).ToList();

            PatientArrival patientArrival = new PatientArrival();
            var hasta = pm.GetByID(id);
            patientArrival.HastaID = hasta.HastaID;
            return View(patientArrival);


        }

        [HttpPost]
        public ActionResult AddPatientArrival(PatientArrival p)
        {
            p.GirisTarihi = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            p.Status = true;
            pam.PatientArrivalAdd(p);
            return RedirectToAction("Index");

        }
            
        public ActionResult ExitPatient(int id)
        {
            var PatientArrivalValue = pam.GetByID(id);      
            PatientArrivalValue.CıkısTarihi = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            PatientArrivalValue.Status = false;
            pam.PatientArrivalUpdate(PatientArrivalValue);  
            return RedirectToAction("Index");
        }   
        
    }
}