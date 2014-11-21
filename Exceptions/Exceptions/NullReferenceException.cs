﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class NullReferenceException : Exception
    {
        public NullReferenceException(string message)
            : base(message + "is empty.")
        { }
    }
}