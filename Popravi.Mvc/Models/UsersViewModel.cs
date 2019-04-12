using Popravi.Business.DataTransfer;
using Popravi.Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popravi.Mvc.Models
{
    public class UsersViewModel
    {
        public PagedResponse<UserDto> Users { get; set; }
        public string PageName { get; } = "Lista korisnika.";
    }
}
