using System;
using System.Collections.Generic;
using System.Text;

namespace RestResource.Entity
{
    public class ErrorInformation
    {
        public string Message { get; set; }
        public List<Error> Errors { get; set; }
    }
}
