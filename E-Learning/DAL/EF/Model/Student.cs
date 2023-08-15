using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Student
    {
        [Key]
        public int Id { set; get; }
        public string fname { set; get; }
        public string lname { set; get; }
        public string email { set; get; }
        public string age { set; get; }

        [ForeignKey("Parent")]
        public int PId { get; set; }
        public virtual Parent Parent{get; set;}
    }
}