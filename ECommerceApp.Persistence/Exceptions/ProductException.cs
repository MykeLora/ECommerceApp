﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string message) : base(message)
        {
        }
    }
}
