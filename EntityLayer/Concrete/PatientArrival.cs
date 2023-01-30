using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PatientArrival
    {
        [Key]
        public int HastaGelisiID { get; set; }
        public DateTime GirisTarihi { get; set; }

        public DateTime? CıkısTarihi { get; set; }
        public Boolean Status { get; set; }

        public int HastaID { get; set; }
        public virtual Patient Patient { get; set; }

        public int ServisID { get; set; }
        public virtual Service Service { get; set; }
        
        public int DoktorID { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
