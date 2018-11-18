using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteCoreSolution.DataProvider
{
    public class SqlDataProvider : ISqlDataProvider
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["SiteCoreConnectionString"].ConnectionString;
        public bool Login(string username, string password, DateTime loginDate)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.Connection = con;
                    command.CommandText = @"DECLARE @Exist int
                                            SELECT @Exist = CASE WHEN EXISTS(SELECT 1 FROM Member WITH (NOLOCK) WHERE UserName=UserName AND Password=@Password) THEN 1 ELSE 0 END


                                            IF @Exist = 1
                                            BEGIN
                                            	INSERT INTO MemberLoginLog(UserName, LoginDate) VALUES(@UserName, @LoginDate)
                                            END
                                            
                                            SELECT @Exist";

                    command.Parameters.Clear();
                    command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                    command.Parameters.Add("@LoginDate", SqlDbType.DateTime).Value = loginDate;
                    return (Convert.ToInt32(command.ExecuteScalar()) == 1);
                }
            }
        }

        public bool Register(string username, string password)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.Connection = con;
                    command.CommandText = @"INSERT INTO Member(UserName, Password) VALUES(@UserName, @Password)";

                    command.Parameters.Clear();
                    command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                    return (Convert.ToInt32(command.ExecuteNonQuery()) > 0);
                }
            }
        }
    }
}