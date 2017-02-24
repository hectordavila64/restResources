using System;
using System.Collections.Generic;
using System.Text;

namespace RestResource.Entity
{
    public class Pagination
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public long Count { get; set; }

        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(Count / Limit * 1.0);
            }
        }
    }


}
