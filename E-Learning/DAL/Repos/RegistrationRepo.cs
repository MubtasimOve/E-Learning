using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RegistrationRepo : Repo, IRepo<Registration, int, bool>,IAuth
    {
        public Registration Authenticate(string username, string password)
        {
            var data = from r in db.Registrations
                       where r.Username.Equals(username)
                       && r.Password.Equals(password)
                       select r;
                
            return data.SingleOrDefault();
        }

        public bool Create(Registration obj)
        {
            db.Registrations.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var db_obj = Get(id);
            db.Registrations.Remove(db_obj);
            return db.SaveChanges() > 0;
        }

        public List<Registration> Get()
        {
            return db.Registrations.ToList();
        }

        public Registration Get(int id)
        {
            return db.Registrations.Find(id);
        }

        public bool Update(Registration obj)
        {
            var db_obj = Get(obj.Id);
            db.Entry(db_obj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }


    }
}