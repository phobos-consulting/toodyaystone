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
/// Summary description for IImageGalleryItem
/// </summary>
public interface IImageControl
{
    ImageItem Image
    {
        set;
    }

    string GalleryName
    {
        set;
    }

    int ThumbnailWidth
    {
        set;
    }
}
