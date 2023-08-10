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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Lesson> Get()
        {
            throw new NotImplementedException();
        }

        public Lesson Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Lesson obj)
        {
            throw new NotImplementedException();
        }
    }
}
