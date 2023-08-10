using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Parent
    {
        [Key]
        public int Id { set; get; }
        public string fname { set; get; }
        public string lname { set; get; }
        public string phone { set; get; }
        public string address { set; get; }

    }
}