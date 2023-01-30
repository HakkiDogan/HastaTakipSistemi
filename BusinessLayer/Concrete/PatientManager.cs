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
    public class PatientManager : IPatientService
    {
        IPatientDal _patientDal;

        public PatientManager(IPatientDal patientDal)
        {
            _patientDal = patientDal;
        }

        public Patient GetByID(int id)
        {
            return _patientDal.Get(x => x.HastaID == id);
        }

        public List<Patient> GetListByHastaGelisi(int id)
        {
            return _patientDal.List(x => x.HastaID == id);
        }

        public List<Patient> GetPatients()
        {
            return _patientDal.List();
        }

        public void PatientAdd(Patient patient)
        {
            _patientDal.Insert(patient);
        }

        public void PatientUpdate(Patient patient)
        {
            _patientDal.Update(patient);
        }
    }
}
