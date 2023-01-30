using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Patient
    {
        [Key]
        public int HastaID { get; set; }

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

        [StringLength(100)]
        public string Adres { get; set; }

        [StringLength(11)]
        public string Tel { get; set; }
        public Boolean Status { get; set; }

        public ICollection<PatientArrival> PatientArrivals { get; set; }

        public ICollection<VitalSignMeasurementValue> VitalSignMeasurementValues { get; set; }


    }
}
