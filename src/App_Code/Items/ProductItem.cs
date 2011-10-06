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
[N2.Definition("Product", "ProductItem")]

public class ProductItem : BaseItem
{

    
    [N2.Details.EditableCheckBox("Show on Homepage", 50)]
    public virtual bool ShowOnHomepage
    {
        get 
        { 
            object showOnHomepageObject = GetDetail("ShowOnHomepage");
            if (showOnHomepageObject == null)
            {
                return false;
            }
            else return (bool)showOnHomepageObject;
        }
        set { SetDetail("ShowOnHomepage", value); }
    }

    [N2.Details.EditableUrl("Product Image", 60)]
    public virtual string ProductImage
    {
        get { return (string)GetDetail("ProductImage") ?? string.Empty; }
        set { SetDetail("ProductImage", value); }
    }

    [N2.Details.EditableFreeTextArea("Teaser", 70)]
    public virtual string Teaser
    {
        get { return (string)GetDetail("Teaser") ?? string.Empty; }
        set { SetDetail("Teaser", value); }
    }

	public override string TemplateUrl
    {
        get { return "/Content.aspx"; }
    }

    public override string IconUrl
    {
        get { return "/Upload/Icons/subhome.gif"; }
    }
}
