using Popravi.Business.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popravi.Mvc.Areas.Admin.Models
{
    public class EditLocationViewModel
    {
        public IEnumerable<CityDto> Cities { get; set; }
        public LocationDto  Location { get; set; }
    }
}
