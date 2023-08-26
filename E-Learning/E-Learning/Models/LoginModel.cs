using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning.Models
{

    public class LoginModel
    {
        public int Id { set; get; }
        public string Username { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Type { set; get; }
    }
}