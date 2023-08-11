using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class NoticeDTO
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public DateTime Date { set; get; }
        public string Description { set; get; }
    }
}
