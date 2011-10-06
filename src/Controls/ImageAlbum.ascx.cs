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

public partial class Controls_ImageAlbum : N2.Web.UI.UserControl<BaseItem>
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (CurrentItem.ShowImageGalleries)
        {
            BindAlbum();
        }
    }

    private void BindAlbum()
    {
        N2.Collections.ItemFilter imageAlbumsFilter = new N2.Collections.TypeFilter(typeof(ImageAlbumItem));
        N2.Collections.ItemList imageAlbumItems = CurrentItem.GetChildren(imageAlbumsFilter);

        foreach (ImageAlbumItem iaItem in imageAlbumItems)
        {
            if (iaItem.GetDetail<bool>("IsVisible", true))
            {
                IImageAlbumPreviewControl iapControl = (IImageAlbumPreviewControl)LoadControl("~/Controls/ImageAlbumPreview.ascx");
                iapControl.ImageAlbum = iaItem;

                Placeholder1.Controls.Add((Control)iapControl);
            }
        }

        N2.Collections.ItemFilter imageGalleriesFilter = new N2.Collections.TypeFilter(typeof(ImageGalleryItem));
        N2.Collections.ItemList imageGalleryItems = CurrentItem.GetChildren(imageGalleriesFilter);

        foreach (ImageGalleryItem igItem in imageGalleryItems)
        {
            if (igItem.GetDetail<bool>("IsVisible", true))
            {
                IImageGalleryControl igControl = (IImageGalleryControl)LoadControl("~/Controls/ImageGallery.ascx");
                igControl.ImageGallery = igItem;
                igControl.ShowTitle = true;

                Placeholder1.Controls.Add((Control)igControl);
            }
        }
    }


}
