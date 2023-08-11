using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LessonRepo : Repo, IRepo<Lesson, int, bool>
    {
        public bool Create(Lesson obj)
        {
            db.Lessons.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var db_obj = Get(id);
            db.Lessons.Remove(db_obj);
            return db.SaveChanges() > 0;
        }

        public List<Lesson> Get()
        {
            return db.Lessons.ToList();
        }

        public Lesson Get(int id)
        {
            return db.Lessons.Find(id);
        }

        public bool Update(Lesson obj)
        {
            var db_obj = Get(obj.Id);
            db.Entry(db_obj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
