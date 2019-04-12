using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Responses
{
    public class PagedResponse<T>
    {
        public int PagesNumber { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
    }
}
