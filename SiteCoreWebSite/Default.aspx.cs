using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteCoreWebSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    LoginName.Visible = true;
                    LoginName.Text = HttpContext.Current.User.Identity.Name;
                    btnLogout.Visible = true;
                    btnLogin.Visible = false;
                    btnRegister.Visible = false;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                LoginName.Visible = false;
                btnLogout.Visible = false;
                btnLogin.Visible = true;
                btnRegister.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}