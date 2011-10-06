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

public partial class Portal_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindContent();
    }

    private void BindContent()
    {
        string username = HttpContext.Current.User.Identity.Name;
        IList<ContentItem> userItems = N2.Find.Items.
               Where.Type.Eq(typeof(UserItem))
               .And.Detail("Username").Eq<string>(username)
               .Select();

        if (userItems.Count > 0)
        {
            UserItem uItem = (UserItem)userItems[0];
            litText.Text = uItem.Text;
            litHeader.Text = uItem.Header;
        }
        
    }
}
