using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Status { set; get; }
        public int TId { set; get; }
        public int LId { get; set; }
    }
}
