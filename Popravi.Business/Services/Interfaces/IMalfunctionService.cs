using Popravi.Business.DataTransfer;
using Popravi.Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Services.Interfaces
{
    public interface IMalfunctionService
    {
        PagedResponse<MalfunctionDto> GetAllMalfunctions(int pageNumber, int perPage);
        void AddMalfunction(MalfunctionDto dto);
        void DeleteMalfunction(int id);
        MalfunctionDto FindMalfunction(int id);
        void UpdateMalfunction(int id, MalfunctionDto dto);
       
    }
}
