using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteCoreWebSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Warning", "alert('You already Login!');", true);
            };

            var webService = new WebService.SiteCoreWebServiceSoapClient();
            var date = DateTime.Now;
            var valid = webService.Login(Login1.UserName, Cryptographer.GenerateSignature(Login1.Password), date.ToString("yyyy-MM-ddTHH:mm:ss"), Cryptographer.GenerateSignature(Login1.UserName + Login1.Password + date.ToString("yyyy-MM-ddTHH:mm")));

            if (valid)
            {             
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

    }
}