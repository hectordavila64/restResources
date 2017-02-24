using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RestResource.Entity
{
    public class Response<T>
    {
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public ErrorInformation Error { get; set; }
    }
}
