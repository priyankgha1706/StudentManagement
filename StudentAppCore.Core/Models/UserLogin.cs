using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAppCore.Core.Models
{
   public  class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
