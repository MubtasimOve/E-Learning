using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseRepo : Repo, IRepo<Course, int, bool>
    {
        public bool Create(Course obj)
        {
            db.Courses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var db_obj = Get(id);
            db.Courses.Remove(db_obj);
            return db.SaveChanges() > 0;
        }

        public List<Course> Get()
        {
            return db.Courses.ToList();
        }

        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }

        public bool Update(Course obj)
        {
            var db_obj = Get(obj.Id);
            db.Entry(db_obj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
