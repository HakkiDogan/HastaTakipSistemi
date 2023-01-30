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
    public class DoctorManager : IDoctorService
    {
        IDoctorDal _doctorDal;

        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }

        public Doctor GetByID(int id)
        {
            return _doctorDal.Get(x => x.DoktorID == id);
        }

        public List<Doctor> GetDoctors()
        {
            return _doctorDal.List();
        }


    }
}
