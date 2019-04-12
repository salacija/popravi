using Popravi.Business.DataTransfer;
using Popravi.Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Services.Interfaces
{
    public interface ILocationService
    {
        PagedResponse<LocationDto> GetAllLocations(int pageNumber, int perPage);
        void DeleteLocation(int id);
        void UpdateLocation(int id, CreateLocationDto dto);
        LocationDto FindLocation(int id);
        void AddLocation(CreateLocationDto dto);

    }
}
