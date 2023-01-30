using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HastaTakip.Controllers
{
    public class DoctorPanelController : Controller
    {
        PatientManager pm = new PatientManager(new EfPatientDal());
        PatientArrivalManager pam = new PatientArrivalManager(new EfPatientArrivalDal());
        VitalSignMeasurementManager vsmm = new VitalSignMeasurementManager(new EfVitalSignMeasurementValueDal());

        
        public ActionResult DoctorProfile()
        {
            return View();
        }

        public ActionResult MyPatient(string p) 
        {
            Context c = new Context();
            p = (string)Session["DoctorMail"];
            var doctorinfo = c.Doctors.Where(x => x.DoktorMail == p).Select(y => y.DoktorID).FirstOrDefault();           
            var values = pam.GetListByDoctor(doctorinfo);
            List<Patient> Hastalar = new List<Patient>();
            foreach (var item in values)
            {
                if (item.Status == true)
                {
                    var nesne = pm.GetListByHastaGelisi(item.HastaID);
                    foreach (var x in nesne)
                    {

                        Patient patient = new Patient();
                        patient.Ad = x.Ad;
                        patient.Soyad = x.Soyad;
                        patient.HastaID = x.HastaID;
                        patient.TC = x.TC;
                        patient.DogumTarihi = x.DogumTarihi;
                        patient.Cinsiyet = x.Cinsiyet;
                        patient.Adres = x.Adres;
                        patient.Tel = x.Tel;
                        Hastalar.Add(patient);
                    }
                }
            }

            return View(Hastalar);


        }

        [HttpGet]
        public ActionResult AddVitalSign(int id)
        {
            Context db = new Context();
            ViewBag.VitalBulgular = db.VitalSigns.ToList().Select(x => new SelectListItem { Text = x.VitalBulguAdi, Value = x.VitalBulguID.ToString() }).ToList();

            VitalSignMeasurementValue vitalsign = new VitalSignMeasurementValue();
            var hasta = pm.GetByID(id);
            vitalsign.HastaID = hasta.HastaID;
            return View(vitalsign);
        }

        [HttpPost]
        public ActionResult AddVitalSign(VitalSignMeasurementValue p)
        {
            p.OlcumZamani = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            vsmm.VitalSignMeasurementValueAdd(p);
            return RedirectToAction("VitalSignByPatient", "VitalSignMeasurement", new { @id = p.HastaID });
        }

    }
}