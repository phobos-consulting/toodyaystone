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

public partial class Controls_HomeContent : N2.Web.UI.UserControl<BaseItem>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        litText.Text = CurrentItem.Text;
    }
}
