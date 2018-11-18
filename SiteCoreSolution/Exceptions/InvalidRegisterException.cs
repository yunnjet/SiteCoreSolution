using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreSolution.Exceptions
{
    public class InvalidRegisterException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Unable to Register! Username:{0}; password: {1}; ";

        public string Username { get; private set; }
        public string Password { get; private set; }

        public InvalidRegisterException(string username, string password) :
            base(string.Format(EXCEPTION_MESSAGE, username, password))
        {
            Username = username;
            Password = password;        
        }

        public InvalidRegisterException(string username, string password, Exception inner) :
            base(string.Format(EXCEPTION_MESSAGE, username, password), inner)
        {
            Username = username;
            Password = password;         
        }
    }
}