using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Course
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Status { set; get; }
        [ForeignKey("Teacher")]
        public int TId { set; get; }
        [ForeignKey("Lesson")]
        public int LId { get; set; }
        public virtual Lesson Lesson { set; get; }
        public virtual Teacher Teacher { set; get; }


    }
}