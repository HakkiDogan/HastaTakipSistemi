using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace HastaTakip.Controllers
{
    public class AdminPatientController : Controller
    {
        PatientManager cm = new PatientManager(new EfPatientDal());        
        [Authorize]
        public ActionResult Index(int p = 1)
        {
            var patientvalues = cm.GetPatients().ToPagedList(p,6);
            return View(patientvalues);
        }

        
        [HttpGet]
        public ActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPatient(Patient p)
        {
            PatientValidator patientvalidator = new PatientValidator();
            ValidationResult result = patientvalidator.Validate(p);
            p.Status = true;

            if (result.IsValid)
            {
                cm.PatientAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
      
        [HttpGet]
        public ActionResult EditPatient(int id)
        {
            var patientvalue = cm.GetByID(id);
            return View(patientvalue);

        }
       
        [HttpPost]
        public ActionResult EditPatient(Patient p)
        {
            PaitentUpdateValidator patientupdatevalidator = new PaitentUpdateValidator();
            ValidationResult result = patientupdatevalidator.Validate(p);

            if (result.IsValid)
            {
                cm.PatientUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}