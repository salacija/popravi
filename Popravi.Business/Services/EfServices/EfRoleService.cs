using Popravi.Business.DataTransfer;
using Popravi.Business.Services.Interfaces;
using Popravi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Popravi.Business.Services.EfServices
{
    public class EfRoleService : BaseEfService, IRoleService
    {
        public EfRoleService(PopraviDbContext context) : base(context)
        {
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            return Context.Roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
        }
    }
}
