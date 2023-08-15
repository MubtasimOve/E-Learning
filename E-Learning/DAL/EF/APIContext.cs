using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class APIContext:DbContext
    {
        public DbSet<Course> Courses { set; get; }
        public DbSet<Lesson> Lessons { set; get; }
        public DbSet<Notice> Notices { set; get; }
        public DbSet<Parent> Parents { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<Registration> Registrations { set; get; }

    }
}
