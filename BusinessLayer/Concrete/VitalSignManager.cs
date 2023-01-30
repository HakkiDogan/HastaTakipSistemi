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
    public class VitalSignManager : IVitalSignService
    {
        IVitalSignDal _vitalsignDal;

        public VitalSignManager(IVitalSignDal vitalsignDal)
        {
            _vitalsignDal = vitalsignDal;
        }

        public VitalSign GetByID(int id)
        {
            return _vitalsignDal.Get(x => x.VitalBulguID == id);
        }

        public List<VitalSign> GetVitalSigns()
        {
            return _vitalsignDal.List();
        }

    }
}

