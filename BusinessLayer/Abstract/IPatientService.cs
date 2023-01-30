using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPatientService
    {
        List<Patient> GetPatients();

        List<Patient> GetListByHastaGelisi(int id);

        void PatientAdd(Patient patient);

        Patient GetByID(int id);

        void PatientUpdate(Patient patient);
    }
}
