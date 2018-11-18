using SiteCoreSolution.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SiteCoreSolution
{
    /// <summary>
    /// Summary description for SiteCoreWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SiteCoreWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Login(string username, string password, string loginDate, string key)
        {
            try
            {
                LoginValidation lv = new LoginValidation();
                DateTime date = DateTime.Parse(loginDate);
                lv.ParameterValidation(username, password, date, key);
                lv.LoginDateValidation(username, date);
                lv.KeyValidation(username, password, date, key);
                lv.Login(username, password, date);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public bool Register(string username, string password, string loginDate, string key)
        {
            try
            {
                LoginValidation lv = new LoginValidation();
                DateTime date = DateTime.Parse(loginDate);
                lv.ParameterValidation(username, password, date, key);
                lv.LoginDateValidation(username, date);
                lv.KeyValidation(username, password, date, key);
                lv.Register(username, password);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
