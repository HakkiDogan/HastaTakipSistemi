using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientArrival> PatientArrivals { get; set; }

        public DbSet<NormalRangeValue> NormalRangeValues { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<VitalSignMeasurementValue> VitalSignMeasurementValues { get; set; }

        public DbSet<VitalSign> VitalSigns { get; set; }

        public DbSet<Admin> Admins { get; set; }

    }
}
