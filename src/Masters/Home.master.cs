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

public partial class Masters_Home : N2.Web.UI.MasterPage<BaseItem>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        litTitle.Text = CurrentPage.Title;
    }
}
