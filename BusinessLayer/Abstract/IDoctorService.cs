using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDoctorService
    {
        List<Doctor> GetDoctors();       
        Doctor GetByID(int id);
    }
}
