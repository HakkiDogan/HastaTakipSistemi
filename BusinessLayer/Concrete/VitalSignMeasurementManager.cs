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
    public class VitalSignMeasurementManager : IVitalSignMeasurementService
    {
        IVitalSignMeasurementDal _vitalSignMeasurementDal;

        public VitalSignMeasurementManager(IVitalSignMeasurementDal vitalSignMeasurementDal)
        {
            _vitalSignMeasurementDal = vitalSignMeasurementDal;
        }

        public VitalSignMeasurementValue GetByID(int id)
        {
            return _vitalSignMeasurementDal.Get(x => x.VitalBulguODID == id);
        }

        public VitalSignMeasurementValue GetByVitalBulguID(int id)
        {
            return _vitalSignMeasurementDal.Get(x => x.VitalBulguID == id);
        }

        public List<VitalSignMeasurementValue> GetList()
        {
            return _vitalSignMeasurementDal.List();
        }

        public List<VitalSignMeasurementValue> GetListByPatient(int id)
        {
            return _vitalSignMeasurementDal.List(x => x.HastaID == id);
        }

        public void VitalSignMeasurementValueAdd(VitalSignMeasurementValue vitalSignMeasurementValue)
        {
            _vitalSignMeasurementDal.Insert(vitalSignMeasurementValue);
        }
       
        public void VitalSignMeasurementValueUpdate(VitalSignMeasurementValue vitalSignMeasurementValue)
        {
            _vitalSignMeasurementDal.Update(vitalSignMeasurementValue);
        }
    }
}
