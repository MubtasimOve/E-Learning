using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Notice
    {
        [Key]
        public int Id { set; get; }
        public string Title { set; get; }
        public DateTime Date { set; get; }
        public string Description { set; get; }
    }
}
