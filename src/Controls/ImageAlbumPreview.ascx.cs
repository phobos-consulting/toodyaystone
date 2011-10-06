using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_ImageAlbumPreview : N2.Web.UI.UserControl<BaseItem>, IImageAlbumPreviewControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAlbum();
    }
    private void BindAlbum()
    {
        AlbumImageLink.ImageUrl = ImageAlbum.AlbumImage;
        AlbumImageLink.NavigateUrl = ImageAlbum.Url;

        AlbumLink.NavigateUrl = ImageAlbum.Url;
        AlbumLink.Text = ImageAlbum.Title;

        TeaserLiteral.Text = StripHtml(ImageAlbum.Teaser);

        MoreLink.NavigateUrl = ImageAlbum.Url;
    }

    protected string StripHtml(object o)
    {
        string html = o.ToString();
        if (html == null || html == string.Empty)
            return string.Empty;

        return System.Text.RegularExpressions.Regex.Replace(html, "<[^>]p*>", string.Empty);
    }

    private ImageAlbumItem _imageAlbum;
    public ImageAlbumItem ImageAlbum
    {
        set
        {
            _imageAlbum = value;
        }
        get
        {
            return _imageAlbum;
        }
    }
}
