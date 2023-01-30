using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class PatientRepository : IPatientDal
    {
        Context c = new Context();

        DbSet<Patient> _object;
        public void Delete(Patient p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(Patient p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Patient> List()
        {
            return _object.ToList();
        }

        public List<Patient> List(Expression<Func<Patient, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient p)
        {
            c.SaveChanges();
        }
    }
}
