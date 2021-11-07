using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_services_ielectric.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        protected BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }

        protected BaseResponse(T resource)
        {
            Success = true;
            Resource = resource;
        }
    }
}
