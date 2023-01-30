using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PatientArrivalManager : IPatientArrivalService
    {
        IPatientArrivalDal _patientArrivalDal;

        public PatientArrivalManager(IPatientArrivalDal patientArrivalDal)
        {
            _patientArrivalDal = patientArrivalDal;
        }

        public PatientArrival GetByID(int id)
        {
            return _patientArrivalDal.Get(x => x.HastaGelisiID == id);
        }

        
        public List<PatientArrival> GetList()
        {
            return _patientArrivalDal.List();
        }
        

        public List<PatientArrival> GetListByPatientID(int id)
        {
            return _patientArrivalDal.List(x => x.HastaID == id);
            
        }
        public List<PatientArrival> GetListByDoctor(int id)
        {
            return _patientArrivalDal.List(x => x.DoktorID == id);
        }


        public void PatientArrivalAdd(PatientArrival patientArrival)
        {
            _patientArrivalDal.Insert(patientArrival);
        }

        public void PatientArrivalDelete(PatientArrival patientArrival)
        {
            _patientArrivalDal.Delete(patientArrival);
        }

        public void PatientArrivalUpdate(PatientArrival patientArrival)
        {
            _patientArrivalDal.Update(patientArrival);
        }
    }
}
