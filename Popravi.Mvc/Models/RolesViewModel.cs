using Popravi.Business.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popravi.Mvc.Models
{
    public class RolesViewModel
    {
        public IEnumerable<RoleDto> Roles { get; set; }
        public string PageName { get; } = "Strana za rad sa ulogama.";
    }
}
