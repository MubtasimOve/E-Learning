using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentRepo:Repo,IRepo<Student,int,bool>
    {
        public bool Create(Student obj)
        {
            db.Students.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var db_obj = Get(id);
            db.Students.Remove(db_obj);
            return db.SaveChanges() > 0;
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public bool Update(Student obj)
        {
            var db_obj = Get(obj.Id);
            db.Entry(db_obj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
