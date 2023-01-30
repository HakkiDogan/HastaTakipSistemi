using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IVitalSignMeasurementService
    {
        List<VitalSignMeasurementValue> GetList();
        List<VitalSignMeasurementValue> GetListByPatient(int id);
        
        void VitalSignMeasurementValueAdd(VitalSignMeasurementValue vitalSignMeasurementValue);

        VitalSignMeasurementValue GetByID(int id);

        void VitalSignMeasurementValueUpdate(VitalSignMeasurementValue vitalSignMeasurementValue);


    }
}
