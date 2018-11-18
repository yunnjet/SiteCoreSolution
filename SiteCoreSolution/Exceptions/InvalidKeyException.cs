using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreSolution.Exceptions
{
    public class InvalidKeyException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Key Not Matched! Username:{0}; password: {1}; LoginDate:{2}; Key:{3}";

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Key { get; private set; }
        public DateTime LoginDate { get; private set; }

        public InvalidKeyException(string username, string password, DateTime loginDate, string key) :
            base(string.Format(EXCEPTION_MESSAGE, username, password, loginDate, key))
        {
            Username = username;
            Password = password;
            LoginDate = loginDate;
            Key = key;
        }

        public InvalidKeyException(string username, string password, DateTime loginDate, string key, Exception inner) :
            base(string.Format(EXCEPTION_MESSAGE, username, password, loginDate, key), inner)
        {
            Username = username;
            Password = password;
            LoginDate = loginDate;
            Key = key;
        }
    }
}