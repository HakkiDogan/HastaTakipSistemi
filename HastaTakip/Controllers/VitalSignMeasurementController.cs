using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using HastaTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HastaTakip.Helper;
using Quartz;
using Quartz.Impl;

namespace HastaTakip.Controllers
{
    public class VitalSignMeasurementController : Controller
    {

        VitalSignMeasurementManager vsmm = new VitalSignMeasurementManager(new EfVitalSignMeasurementValueDal());
        PatientManager pm = new PatientManager(new EfPatientDal());

        public ActionResult VitalSignByPatient(int id)
        {
            ViewBag.id = id;
            TempData["id"] = id;
            
                //son bulgular                
                ViewBag.sonsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
                ViewBag.sonates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
                ViewBag.sonsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
                ViewBag.sondiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
                ViewBag.sonnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
                ViewBag.sonkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
                ViewBag.sonoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();

                //son tarihler
                ViewBag.sonsolunumtarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
                ViewBag.sonatestarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
                ViewBag.sonsistoliktarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
                ViewBag.sondiastoliktarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
                ViewBag.sonnabıztarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
                ViewBag.sonkansekeritarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
                ViewBag.sonoksijentarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
                
                //son 10 gün min değer
                ViewBag.son10minsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son10minates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son10minsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son10mindiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son10minnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son10minkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son10minoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();

                //son 10 gün max değer
                ViewBag.son10maxsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son10maxates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son10maxsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son10maxdiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son10maxnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son10maxkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son10maxoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                 
                //son 1 gün min değer
                ViewBag.son1minsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son1minates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son1minsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son1mindiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son1minnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son1minkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
                ViewBag.son1minoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();

                //son 1 gün max değer
                ViewBag.son1maxsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son1maxates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son1maxsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son1maxdiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son1maxnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son1maxkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
                ViewBag.son1maxoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
  
            var vitalsignvalues = vsmm.GetListByPatient(id);
            return View(vitalsignvalues);
        }

        public ActionResult AdminVitalSignByPatient(int id)
        {
            ViewBag.id = id;
            TempData["id"] = id;

            //son bulgular                
            ViewBag.sonsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
            ViewBag.sonates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
            ViewBag.sonsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
            ViewBag.sondiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
            ViewBag.sonnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
            ViewBag.sonkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();
            ViewBag.sonoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Last();

            //son tarihler
            ViewBag.sonsolunumtarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
            ViewBag.sonatestarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
            ViewBag.sonsistoliktarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
            ViewBag.sondiastoliktarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
            ViewBag.sonnabıztarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
            ViewBag.sonkansekeritarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();
            ViewBag.sonoksijentarih = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12).Select(y => y.OlcumZamani).DefaultIfEmpty().Last();

            //son 10 gün min değer
            ViewBag.son10minsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son10minates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son10minsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son10mindiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son10minnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son10minkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son10minoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();

            //son 10 gün max değer
            ViewBag.son10maxsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son10maxates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son10maxsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son10maxdiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son10maxnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son10maxkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son10maxoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12 && x.OlcumZamani.AddDays(10) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();

            //son 1 gün min değer
            ViewBag.son1minsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son1minates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son1minsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son1mindiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son1minnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son1minkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();
            ViewBag.son1minoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Min();

            //son 1 gün max değer
            ViewBag.son1maxsolunum = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 9 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son1maxates = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 1 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son1maxsistolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 4 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son1maxdiastolik = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 8 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son1maxnabız = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 10 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son1maxkansekeri = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 11 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();
            ViewBag.son1maxoksijen = vsmm.GetList().Where(x => x.HastaID == id && x.VitalBulguID == 12 && x.OlcumZamani.AddDays(1) >= DateTime.Now).Select(y => y.OlcumDeğeri).DefaultIfEmpty().Max();

            var vitalsignvalues = vsmm.GetListByPatient(id);
            return View(vitalsignvalues);
        }

        [HttpGet]
        public ActionResult AddVitalSign(int id)
        {
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
        public ActionResult AdminAtes()
        {
            return View();
        }

        public ActionResult AdminSisTan()
        {
            return View();
        }

        public ActionResult AdminDiaTan()
        {
            return View();
        }

        public ActionResult AdminSolunum()
        {
            return View();
        }

        public ActionResult Ates()
        {
            return View();
        }

        public ActionResult SisTan()
        {           
            return View();
        }

        public ActionResult DiaTan()
        {
            return View();
        }

        public ActionResult Solunum()
        {
            return View();
        }

        public ActionResult GetAtes(int id)
        {
            ViewBag.id = id;
            DbHastaKayitEntities4 context = new DbHastaKayitEntities4();
            var data = context.VitalSignMeasurementValues.Where(x => x.HastaID == id && x.VitalBulguID == 1).Select(y => new { olcum = y.OlcumDeğeri, tarih = y.OlcumZamani.ToString() }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSisTan(int id)
        {
            ViewBag.id = id;
            DbHastaKayitEntities4 context = new DbHastaKayitEntities4();
            var data = context.VitalSignMeasurementValues.Where(x => x.HastaID == id && x.VitalBulguID == 4).Select(y => new { olcum = y.OlcumDeğeri, tarih = y.OlcumZamani.ToString() }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDiaTan(int id)
        {
            ViewBag.id = id;
            DbHastaKayitEntities4 context = new DbHastaKayitEntities4();
            var data = context.VitalSignMeasurementValues.Where(x => x.HastaID == id && x.VitalBulguID == 8).Select(y => new { olcum = y.OlcumDeğeri, tarih = y.OlcumZamani.ToString() }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSolunum(int id)
        {
            ViewBag.id = id;
            DbHastaKayitEntities4 context = new DbHastaKayitEntities4();
            var data = context.VitalSignMeasurementValues.Where(x => x.HastaID == id && x.VitalBulguID == 9).Select(y => new { olcum = y.OlcumDeğeri, tarih = y.OlcumZamani.ToString() }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddVitalSignAll(int id)
        {
            StartScheduler(id);
            return RedirectToAction("VitalSignByPatient", "VitalSignMeasurement", new { @id = TempData["id"] });
        }

        private static void StartScheduler(int id)
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            IScheduler sched = schedFact.GetScheduler();
            sched.Start();

            IJobDetail job = JobBuilder.Create<SetVitalValue>().UsingJobData("id", id).WithIdentity("job1", "group1").Build();

            ITrigger trigger = TriggerBuilder.Create().WithIdentity("job1", "group1").StartAt(DateTime.Now)
                .WithSimpleSchedule(x => x.WithIntervalInMinutes(30).WithRepeatCount(48)).Build();
            sched.ScheduleJob(job, trigger);
        }

        public class SetVitalValue : IJob
        {
            void IJob.Execute(IJobExecutionContext context)
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;

                int id = dataMap.GetInt("id");
                AutoAddVitalSign.AddAllVitalSign(id);
            }
        }


    }
}