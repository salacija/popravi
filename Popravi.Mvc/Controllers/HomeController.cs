using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Popravi.Business.DataTransfer;
using Popravi.Business.Services.EfServices;
using Popravi.Business.Services.Interfaces;
using Popravi.DataAccess;
using Popravi.Mvc.Models;

namespace Popravi.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new RolesViewModel();
            var context = new PopraviDbContext();

            IRoleService svc = new EfRoleService(context);

            vm.Roles = svc.GetRoles();

            return View(vm);
        }
    }
}
