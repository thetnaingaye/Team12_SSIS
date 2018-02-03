//Author: Lim Chang Siang
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team12_SSIS.Exceptions
{
    public class EmailControlException : Exception
    {
        public EmailControlException()
        {
        }

        public EmailControlException(string message)
        : base(message)
        {
        }

        public EmailControlException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}