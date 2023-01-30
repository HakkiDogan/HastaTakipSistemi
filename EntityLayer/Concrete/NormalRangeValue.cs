using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class NormalRangeValue
    {
        [Key]
        public int NormalAralikDegeriID { get; set; }
    
        public int MinYas { get; set; }

        public int MaxYas { get; set; }

        [StringLength(5)]
        public string Cinsiyet { get; set; }

        public double MinDeger { get; set; }

        public double MaxDeger { get; set; }

        //public Boolean Status { get; set; }

        public int VitalBulguID { get; set; }
        public virtual VitalSign VitalSign { get; set; }

    }
}
