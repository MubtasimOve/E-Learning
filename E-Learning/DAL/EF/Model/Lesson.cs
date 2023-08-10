using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descriotion { get; set; }
        public string File { get; set; }

    }
}