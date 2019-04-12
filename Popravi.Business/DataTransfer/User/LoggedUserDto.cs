using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.DataTransfer.User
{
   public class LoggedUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
