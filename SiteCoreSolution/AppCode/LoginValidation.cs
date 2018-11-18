using SiteCoreSolution.DataProvider;
using SiteCoreSolution.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreSolution.AppCode
{
    public class LoginValidation
    {
        private ISqlDataProvider _sqlDataProvider;

        private ISqlDataProvider SqlDataProvider
        {
            get
            {
                if(_sqlDataProvider == null)
                {
                    _sqlDataProvider = new SqlDataProvider();
                }
                return _sqlDataProvider;
            }

            set { _sqlDataProvider = value; }
        }

        public void ParameterValidation(string membercode, string password, DateTime loginDate, string key)
        {
            if(string.IsNullOrEmpty(membercode) 
                || string.IsNullOrEmpty(password) 
                || string.IsNullOrEmpty(key)
                || loginDate == null)
            {
                throw new InvalidParameterException(membercode, password, loginDate, key);
            }
        }

        public void LoginDateValidation(string membercode, DateTime loginDate)
        {
            if (DateTime.Now.AddMinutes(5) < loginDate || DateTime.Now.AddMinutes(-1) > loginDate)
            {
                throw new TimeExpiredException(membercode, loginDate);
            }
        }

        public void KeyValidation(string membercode, string password, DateTime loginDate, string key)
        {
            if (!Cryptographer.GenerateSignature(membercode + password + loginDate.ToString("yyyy-MM-ddTHH:mm")).Equals(key))
            {
                throw new InvalidKeyException(membercode, password, loginDate, key);
            }
        }

        public void Login(string membercode, string password, DateTime loginDate)
        {
            if (!SqlDataProvider.Login(membercode, password, loginDate))
            {
                throw new InvalidLoginException(membercode, password, loginDate);
            }
        }

        public void Register(string membercode, string password)
        {
            if (!SqlDataProvider.Register(membercode, password))
            {
                throw new InvalidRegisterException(membercode, password);
            }
        }
    }
}