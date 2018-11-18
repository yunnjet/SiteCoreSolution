using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreSolution.Exceptions
{
    public class TimeExpiredException : Exception
    {
        private const string EXCEPTION_MESSAGE = "LoginDate exceeded time range! Username:{0}; LoginDate:{1}";

        public string Username { get; private set; }
        public DateTime LoginDate { get; private set; }

        public TimeExpiredException(string username, DateTime loginDate) :
            base(string.Format(EXCEPTION_MESSAGE, username, loginDate))
        {
            Username = username;
            LoginDate = loginDate;
        }

        public TimeExpiredException(string username, DateTime loginDate, Exception inner) :
            base(string.Format(EXCEPTION_MESSAGE, username, loginDate), inner)
        {
            Username = username;
            LoginDate = loginDate;
        }
    }
}