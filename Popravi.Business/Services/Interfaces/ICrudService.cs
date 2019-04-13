using Popravi.Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Services.Interfaces
{
    public interface ICrudService<TResult, TInsert, TUpdate>
    {
        PagedResponse<TResult> GetAll(int pageNumber, int perPage);
        IEnumerable<TResult> GetAll();
        void Add(TInsert dto);
        void Delete(int id);
        void Update(int id, TUpdate dto);
        TResult Find(int id);
    }
}
