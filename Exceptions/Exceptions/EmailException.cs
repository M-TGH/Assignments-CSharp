using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class EmailException : Exception
    {
        public EmailException(string message)
            : base(message)
        { }
    }
}
