using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Wrappers
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            this.Success = true;
        }
        public string Message { get; set; }
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}

