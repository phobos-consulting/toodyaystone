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
[N2.Definition("Image gallery", "ImageGalleryItem")]

public class ImageGalleryItem : BaseItem
{

    [N2.Details.EditableCheckBox("Show on navigation", 50)]
    public virtual bool ShowOnNavigation
    {
        get
        {
            object show = GetDetail("ShowOnNavigation");
            if (show == null)
            {
                return true;
            }
            else return (bool)show;
        }
        set { SetDetail("ShowOnNavigation", value); }
    }

    [N2.Details.EditableCheckBox("Show images", 60)]
    public virtual bool ShowImages
    {
        get
        {
            object show = GetDetail("ShowImages");
            if (show == null)
            {
                return true;
            }
            else return (bool)show;
        }
        set { SetDetail("ShowImages", value); }
    }

    [N2.Details.EditableCheckBox("Link from gallery header", 70)]
    public virtual bool LinkFromHeader
    {
        get
        {
            object show = GetDetail("LinkFromHeader");
            if (show == null)
            {
                return false;
            }
            else return (bool)show;
        }
        set { SetDetail("LinkFromHeader", value); }
    }

    [EditableOneToTenPicker("Number of Columns", 80)]
    public virtual int Columns
    {
        get
        {
            object oColumns = GetDetail("Columns");

            if (oColumns == null)
            {
                return 5;
            }
            else return Convert.ToInt32(GetDetail("Columns"));
        }
        set { SetDetail("Columns", value); }
    }

    [N2.Details.EditableTextBox("Thumbnail Width", 90)]
    public virtual int ThumbnailWidth
    {
        get
        {
            object oColumns = GetDetail("ThumbnailWidth");

            if (oColumns == null)
            {
                return 100;
            }
            else return Convert.ToInt32(GetDetail("ThumbnailWidth"));
        }
        set { SetDetail("ThumbnailWidth", value); }
    }



    [N2.Details.EditableFreeTextArea("Teaser", 100)]
    public virtual string Teaser
    {
        get { return (string)GetDetail("Teaser") ?? string.Empty; }
        set { SetDetail("Teaser", value); }
    }

   public override string IconUrl
    {
        get { return "/Upload/Icons/imagegallery.gif"; }
    }


	public override string TemplateUrl
    {
        get { return "/imagegallery.aspx"; }
    }
}
