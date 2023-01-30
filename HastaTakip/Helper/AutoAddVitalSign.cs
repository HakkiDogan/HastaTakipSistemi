using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using HastaTakip.Controllers;

namespace HastaTakip.Helper
{
    public class AutoAddVitalSign
    {       
        public static void AddAllVitalSign(int id)
        { 
            
            VitalSignMeasurementManager vsmm = new VitalSignMeasurementManager(new EfVitalSignMeasurementValueDal());
            PatientManager pm = new PatientManager(new EfPatientDal());                    
            VitalSignMeasurementValue vitalsign = new VitalSignMeasurementValue();
            int[] vitalid = new int[] { 1, 4, 8, 9, 10, 11, 12 };
            foreach (var item in vitalid)
            {
                Random random = new Random();               
                var hasta = pm.GetByID(id);
                vitalsign.HastaID = hasta.HastaID;
                vitalsign.OlcumZamani = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                vitalsign.VitalBulguID = item;
                if (item == 1)
                {
                    double deger = random.NextDouble() + 36;
                    string sayi = deger.ToString("N2");
                    vitalsign.OlcumDeğeri = Convert.ToDouble(sayi);
                }
                else if (item == 4)
                {
                    vitalsign.OlcumDeğeri = random.Next(90,120);
                }
                else if(item == 8)
                {
                    vitalsign.OlcumDeğeri = random.Next(60,80);
                }
                else if(item == 9)
                {
                    vitalsign.OlcumDeğeri = random.Next(20,30);
                }
                else if(item == 10)
                {
                    vitalsign.OlcumDeğeri = random.Next(80,100);
                }
                else if(item == 11)
                {
                    vitalsign.OlcumDeğeri = random.Next(70, 125);
                }
                else 
                {
                    vitalsign.OlcumDeğeri = random.Next(95, 100);
                }
                vsmm.VitalSignMeasurementValueAdd(vitalsign);                
            }
        }
    }
}