using System;
using System.Collections.Generic;
using System.Text;

namespace RestResource.Entity
{
    public class Sorting
    {
        public SortingDirection OrderDirection { get; set; }
        public string OrderFieldName { get; set; }       
    }    
}
