using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TeacherRepo : Repo, IRepo<Teacher, int, bool>
    {
        public bool Create(Teacher obj)
        {
            db.Teachers.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var db_obj = Get(id);
            db.Teachers.Remove(db_obj);
            return db.SaveChanges() > 0;
        }

        public List<Teacher> Get()
        {
            return db.Teachers.ToList();
        }

        public Teacher Get(int id)
        {
            return db.Teachers.Find(id);
        }

        public bool Update(Teacher obj)
        {
            var db_obj = Get(obj.Id);
            db.Entry(db_obj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
