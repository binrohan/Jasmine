using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Helpers
{
    public class Response
    {
        public object Id { get; set; }
        public object Data { get; set; }
        public bool IsError { get; set; }
        public string Msg { get; set; }
        
        public Response(object id, object data, bool isError, string message)
        {
            Id = id;
            Data = data;
            IsError = isError;
            Msg = message;
        }
        
    }
}
