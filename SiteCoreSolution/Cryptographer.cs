using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SiteCoreSolution
{
    public class Cryptographer
    {
        private static string SecretKey = ConfigurationManager.AppSettings["SecretKey"];
        public static string GenerateSignature(string rawRequestMsg)
        {
            return BuildMD5(rawRequestMsg + SecretKey);
        }

        private static string BuildMD5(string rawRequestMsg)
        {
            var hashed = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(rawRequestMsg));
            var sb = new StringBuilder(hashed.Length * 2);
            for (var i = 0; i < hashed.Length; i++)
            {
                sb.Append(hashed[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}