using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeDoDigital.PhoneBook.Core.Common.Exceptions;

namespace WeDoDigital.PhoneBook.Core.Common.Wrappers
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data, string message = null)
        {
            Data = data;
            Message = message;
            Succeeded = true;
        }

        public Response(string message)
        {
            Message = message;
            Succeeded = true;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<ErrorModel> Errors { get; set; }
        public T Data { get; set; }
    }
}
