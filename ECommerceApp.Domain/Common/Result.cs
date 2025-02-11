using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Common
{
    public class Result
    {
        public Result()
        {
            this.Success = true;
        }
        public string? Message { get; set; }
        public bool Success { get; set; }
        public dynamic? Data { get; set; }

    }
}
