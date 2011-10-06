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

public partial class Controls_Products : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        IList<ContentItem> featureItemsList = N2.Find.Items
                .Where.Type.Eq(typeof(ProductItem))
                .And.Detail("ShowOnHomePage").Eq<bool>(true)
                .Select();

            ProductsRepeater.DataSource = featureItemsList;
            ProductsRepeater.DataBind();
        
    }

    protected string StripHtml(object o)
    {
        string html = o.ToString();
        if (html == null || html == string.Empty)
            return string.Empty;

        return System.Text.RegularExpressions.Regex.Replace(html, "<[^>]p*>", string.Empty);
    }

    private static string StripParagraph(string html)
    {
        if (html == null || html == string.Empty)
            return string.Empty;

        return System.Text.RegularExpressions.Regex.Replace(html, "<[^>]p*>", string.Empty);
    } 
}
