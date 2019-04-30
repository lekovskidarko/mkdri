using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Dtos
{
    public class RequestError: Exception
    {
        public int Status { get; set; }
        public string Message { get; set; }

        public RequestError(string message)
        {
            Status = 403;
            Message = message;
        }

        public RequestError(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
