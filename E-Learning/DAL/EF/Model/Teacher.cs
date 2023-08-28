﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Teacher
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public virtual ICollection<Course> Courses { get; set; }
        public Teacher()
        {
            Courses = new List<Course>();
        }
    }
}