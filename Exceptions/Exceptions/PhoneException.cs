using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class PhoneException : Exception
    {
        public PhoneException(string message)
            : base(message)
        { }
    }
}
