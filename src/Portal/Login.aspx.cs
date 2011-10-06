using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using N2;
using N2.Collections;

public partial class Portal_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        IList<ContentItem> userItems = N2.Find.Items.
                Where.Type.Eq(typeof(UserItem))
                .And.Detail("Username").Eq<string>(txtUsername.Text)
                .And.Detail("Password").Eq<string>(txtPassword.Text)
                .Select();

        Response.Write(userItems.Count.ToString());
        if (userItems.Count > 0)
        {

            FormsAuthentication.Initialize();
            UserItem uItem = (UserItem)userItems[0];

            string roles = uItem.Name;

            // Create the authentication ticket
            FormsAuthenticationTicket authTicket = new
              FormsAuthenticationTicket(1,  // version
              txtUsername.Text,             // user name
              DateTime.Now,                 // creation
              DateTime.Now.AddMinutes(20),   // expiration
              false,                        // persistent
              roles);                       // user data

            // Encrypt the ticket
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            // Create a cookie and add ticket to cookie
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            // Add the cookie to the outgoing cookies collection
            Response.Cookies.Add(authCookie);

            // Redirect the user to the originally requested page
            string redirectUrl = FormsAuthentication.GetRedirectUrl(txtUsername.Text, false);
            Response.Redirect(redirectUrl);


        }
        else
        {
            lblWrongPassword.Text = "Sorry, username or <br> password was not correct.";
        }
    }
}
