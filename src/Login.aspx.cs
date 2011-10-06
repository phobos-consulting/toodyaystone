using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string originalUrl = (string)FormsAuthentication.GetRedirectUrl("", true);

        if (originalUrl.ToLower().IndexOf("/portal/") >= 0)
        {
          string redirectUrl = string.Format("/portal/login.aspx?ReturnUrl={0}", originalUrl);
        
            Response.Redirect(redirectUrl);
        }
        
    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            if (FormsAuthentication.Authenticate(Login1.UserName, Login1.Password))
            {
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
            }
            else if (System.Web.Security.Membership.ValidateUser(Login1.UserName, Login1.Password))
            {
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
            }
        }
        catch (Exception ex)
        {
            Trace.Warn(ex.ToString());
            e.Authenticated = false;
        }
    }
}
