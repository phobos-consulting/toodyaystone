using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using N2;

/// <summary>
/// This is my custom content data container class. Since this class derives 
/// from <see cref="N2.ContentItem"/> N2 will pick up this class and make it 
/// available when we create pages in edit mode. 
/// 
/// Another thing to notice is that in addition to Text defined to be editable 
/// in this class it's Title and Name are also editable. This is because of the 
/// abstract base class <see cref="MyItemBase"/> it derives from.
/// </summary>
[N2.Definition("Image", "ImageItem")]

public class ImageItem : ReferenceBaseItem
{
    [N2.Details.EditableTextBox("Caption", 20)]
    public virtual string Caption
    {
        get { return (string)GetDetail("Caption") ?? string.Empty; }
        set { SetDetail("Caption", value); }
    }

    [N2.Details.EditableImage("Image", 50)]
    public virtual string ImageUrl
    {
        get { return (string)GetDetail("ImageUrl") ?? string.Empty; }
        set { SetDetail("ImageUrl", value); }
    }

    public override string TemplateUrl
    {
        get { return "/Image.aspx"; }
    }

    public override string IconUrl
    {
        get { return "/Upload/Icons/image.gif"; }
    }

    public override string LargeIconUrl
    {
        get { return "/Upload/Icons/image_large.gif"; }
    }
}
