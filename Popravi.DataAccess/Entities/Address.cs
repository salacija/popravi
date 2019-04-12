using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.DataAccess.Entities
{
    public class Address : BaseEntity
    {
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string StreetName { get; set; }
        public string HomeNumber { get; set; }
        public string ZipCode { get; set; }

        public City City { get; set; }
    }
}
