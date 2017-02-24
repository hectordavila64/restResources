using System;
using System.Collections.Generic;
using System.Text;

namespace RestResource.Entity
{
    public class Error
    {
        public string Resource { get; set; }
        public string Field { get; set; }
        public string Code { get; set; }
    }
}
