using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
