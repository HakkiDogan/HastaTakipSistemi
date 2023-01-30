using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Service
    {
        [Key]
        public int ServisID { get; set; }

        [StringLength(50)]
        public string ServisAdi { get; set; }

        public ICollection<PatientArrival> PatientArrivals { get; set; }

    }
}
