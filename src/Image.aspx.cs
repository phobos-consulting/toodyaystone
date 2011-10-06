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

public partial class Image : N2.Web.UI.Page<ImageItem>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        litCaption.Text = CurrentPage.Caption;
        Image1.ImageUrl = CurrentPage.ImageUrl;
    }
}
