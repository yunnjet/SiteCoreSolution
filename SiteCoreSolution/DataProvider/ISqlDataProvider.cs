using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteCoreSolution.DataProvider
{
    interface ISqlDataProvider
    {
        bool Login(string username, string password, DateTime loginDate);
        bool Register(string username, string password);
    }
}
