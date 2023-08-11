using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ParentRepo : Repo, IRepo<Parent, int, bool>
    {
        public bool Create(Parent obj)
        {
            db.Parents.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var db_obj = Get(id);
            db.Parents.Remove(db_obj);
            return db.SaveChanges() > 0;
        }

        public List<Parent> Get()
        {
            return db.Parents.ToList();
        }

        public Parent Get(int id)
        {
            return db.Parents.Find(id);
        }

        public bool Update(Parent obj)
        {
            var db_obj = Get(obj.Id);
            db.Entry(db_obj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
