using Popravi.Business.DataTransfer;
using Popravi.Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Services.Interfaces
{
    public interface ILocationService : ICrudService<LocationDto, CreateLocationDto, CreateLocationDto>
    {
    }
}
