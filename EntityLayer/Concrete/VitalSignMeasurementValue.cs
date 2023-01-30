using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class VitalSignMeasurementValue
    {
        [Key]
        public int VitalBulguODID { get; set; }

        public DateTime OlcumZamani { get; set; }

        public double OlcumDeğeri { get; set; }

        public Boolean Status { get; set; }

        public int VitalBulguID { get; set; }
        public virtual VitalSign VitalSign { get; set; }

        public int HastaID { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
