using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// This is my custom content data container class. Since this class derives 
/// from <see cref="N2.ContentItem"/> N2 will pick up this class and make it 
/// available when we create pages in edit mode. 
/// 
/// Another thing to notice is that in addition to Text defined to be editable 
/// in this class it's Title and Name are also editable. This is because of the 
/// abstract base class <see cref="MyItemBase"/> it derives from.
/// </summary>
[N2.Definition("Home page", "HomeItem")]

public class HomeItem : BaseItem
{

    [N2.Details.EditableFreeTextArea("Navigation feature", 50)]
    public virtual string NavigationFeature
    {
        get { return (string)GetDetail("NavigationFeature"); }
        set { SetDetail("NavigationFeature", value); }
    }

    public override string TemplateUrl
    {
        get { return "/Default.aspx"; }
    }

    public override string IconUrl
    {
	    get 
	    { 
		     return "/Upload/Icons/home.gif";
	    }
    }
   
}
