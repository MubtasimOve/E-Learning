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
        public static IRepo<Course,int,bool> CourseDataAccess()
        {
            return new CourseRepo();
        }
        public static IRepo<Lesson, int, bool> LessonDataAccess()
        {
            return new LessonRepo();
        }
        public static IRepo<Teacher, int, bool> TeacherDataAccess()
        {
            return new TeacherRepo();
        }
        public static IRepo<Notice, int, bool> NoticeDataAccess()
        {
            return new NoticeRepo();
        }
        public static IRepo<Parent, int, bool> ParentDataAccess()
        {
            return new ParentRepo();
        }
        public static IRepo<Student, int, bool> StudentDataAccess()
        {
            return new StudentRepo();
        }
        public static IRepo <Registration,int ,bool>RegistrationDataAccess()
        {
            return new RegistrationRepo();
        }

    }
}
