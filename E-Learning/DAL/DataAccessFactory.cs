using DAL.EF.Model;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Course,int,bool> CourseDataAcess()
        {
            return new CourseRepo();
        }
        public static IRepo<Lesson, int, bool> LessonDataAcess()
        {
            return new LessonRepo();
        }
        public static IRepo<Teacher, int, bool> TeacherDataAcess()
        {
            return new TeacherRepo();
        }


    }
}
