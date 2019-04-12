using Popravi.Business.DataTransfer;
using Popravi.Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Services.Interfaces
{
    public interface ICityService
    {
        PagedResponse<CityDto> GetAllCities(int pageNumber, int perPage);
        IEnumerable<CityDto> GetAllCities();
        void AddCity(CityDto dto);
        void DeleteCity(int id);
        void UpdateCity(int id, CityDto dto);
        CityDto FindCity(int id);
    }
}
