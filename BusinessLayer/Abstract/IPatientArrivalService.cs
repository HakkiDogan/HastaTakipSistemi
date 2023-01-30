using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPatientArrivalService
    {
        List<PatientArrival> GetList();

        List<PatientArrival> GetListByPatientID(int id);

        void PatientArrivalAdd(PatientArrival patientArrival);
        void PatientArrivalDelete(PatientArrival patientArrival);
        void PatientArrivalUpdate(PatientArrival patientArrival);

        PatientArrival GetByID(int id);



    }
}
