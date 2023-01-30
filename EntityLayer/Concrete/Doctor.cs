using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Doctor
    {
        [Key]
        public int DoktorID { get; set; }
       
        [StringLength(11)]
        [Index(IsUnique = true)]
        public string TC { get; set; }

        [StringLength(30)]
        public string Ad { get; set; }

        [StringLength(20)]
        public string Soyad { get; set; }

        [StringLength(10)]
        public string DogumTarihi { get; set; }

        [StringLength(5)]
        public string Cinsiyet { get; set; }

        [StringLength(11)]
        public string Tel { get; set; }

        [StringLength(50)]
        public string DoktorMail { get; set; }

        [StringLength(30)]
        public string DoktorSifre { get; set; }

        public Boolean Status { get; set; }

        public ICollection<PatientArrival> PatientArrivals { get; set; }



    }
}
