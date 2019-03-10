using Popravi.Business.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Services.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetRoles();
    }
}
