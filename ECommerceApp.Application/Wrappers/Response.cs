using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Wrappers
{
    // Standardized API response structure.
    // T represents then Type of the response data
    public abstract class BaseResponse
    {
        protected BaseResponse()
        {
            this.IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}


