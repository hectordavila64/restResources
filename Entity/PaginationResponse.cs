using System;
using System.Collections.Generic;
using System.Text;

namespace RestResource.Entity
{
    public class PaginationResponse<T>
    {
        public List<T> Entities { get; set; }
        public Pagination Pagination { get; set; }
        public Sorting Sorting { get; set; }
    }
}
