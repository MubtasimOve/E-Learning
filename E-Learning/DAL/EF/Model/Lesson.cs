using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Descriotion { get; set; }
        public string File { get; set; }

    }
}