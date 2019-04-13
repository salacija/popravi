using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public static int UserRoleId => 4;
        public static int AdminRoleId => 1;
    }
}
