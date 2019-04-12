using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
