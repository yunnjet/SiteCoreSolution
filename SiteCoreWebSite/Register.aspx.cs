using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteCoreWebSite
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Warning", "alert('You already Registered!');", true);
                };

                var webService = new WebService.SiteCoreWebServiceSoapClient();
                var date = DateTime.Now;
                var password = Cryptographer.GenerateSignature(txtPassword.Text);
                var valid = webService.Register(txtUserName.Text, password, date.ToString("yyyy-MM-ddTHH:mm:ss"), Cryptographer.GenerateSignature(txtUserName.Text + password + date.ToString("yyyy-MM-ddTHH:mm")));

                if (valid)
                {
                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true);
                }else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Warning", "alert('Fail to Register!');", true);
                }
            }
        }
    }
}