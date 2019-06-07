using System;
namespace MKDRI.Dtos
{
    public class RequestError: Exception
    {
        public int Status { get; set; }
        public override string Message { get; }

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
