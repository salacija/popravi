using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string ActivationCode { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Address> Addresses { get; set; }
        
    }
}
