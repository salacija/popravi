using Popravi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Services.EfServices
{
    public abstract class BaseEfService
    {
        protected readonly PopraviDbContext Context;

        protected BaseEfService(PopraviDbContext context) => Context = context;
    }
}
