using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreSolution.Exceptions
{
    public class InvalidLoginException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Wrong Username and Password! Username:{0}; password: {1}; LoginDate:{2};";

        public string Username { get; private set; }
        public string Password { get; private set; }
        public DateTime LoginDate { get; private set; }

        public InvalidLoginException(string username, string password, DateTime loginDate) :
            base(string.Format(EXCEPTION_MESSAGE, username, password, loginDate))
        {
            Username = username;
            Password = password;
            LoginDate = loginDate;
        }

        public InvalidLoginException(string username, string password, DateTime loginDate, Exception inner) :
            base(string.Format(EXCEPTION_MESSAGE, username, password, loginDate), inner)
        {
            Username = username;
            Password = password;
            LoginDate = loginDate;
        }
    }
}