using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class VitalSign
    {
        [Key]
        public int VitalBulguID { get; set; }

        [StringLength(30)]
        public string VitalBulguAdi { get; set; }

        //public Boolean Status { get; set; }

        public ICollection<VitalSignMeasurementValue> VitalSignMeasurementValues { get; set; }

        public ICollection<NormalRangeValue> NormalRangeValues { get; set; }

    }
}
