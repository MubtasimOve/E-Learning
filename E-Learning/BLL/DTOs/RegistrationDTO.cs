using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RegistrationDTO
    {
        public int Id { set; get; }
        public string Username { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Type { set; get; }
    }
}
