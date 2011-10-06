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

public partial class Controls_Image : System.Web.UI.UserControl, IImageControl
{
    private ImageItem _imageItem;
    private string _galleryName = string.Empty;
    private int _thumbnailWidth = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        BindLiteral();
    }

    private void BindLiteral()
    {
        string imageUrl = _imageItem.ImageUrl;
        string imagePath = Server.MapPath(imageUrl);

        string thumbFolderUrl = ConfigurationManager.AppSettings["ThumbnailFolderUrl"];
        string thumbFolderPath = Server.MapPath(thumbFolderUrl);

        string thumbExtension = "_thumb" + _thumbnailWidth.ToString();
        
        ImageUtil.AddThumbnail(imagePath, _thumbnailWidth, thumbExtension, thumbFolderPath);

        string thumbUrl = ImageUtil.GetThumbnailUrl(imageUrl, thumbExtension, thumbFolderUrl);

        LightboxLiteral.Text = BuildLightboxLiteral(imageUrl, thumbUrl);
        LightboxPanel.Width = Unit.Pixel(_thumbnailWidth);
        
    }

    private string BuildLightboxLiteral(string imageUrl, string thumbUrl)
    {

        string controlFormat = "<a href=\"{0}\" rel=\"lightbox[{1}]\" title=\"{2}\">";
        controlFormat += "<img src=\"{3}\" border=\"0\" />";
        controlFormat += "</a>";
        controlFormat += "<div class=\"gallery_caption\">{4}</div>";
        return string.Format(controlFormat, imageUrl, _galleryName, _imageItem.Caption, thumbUrl, _imageItem.Caption);
    }

    public ImageItem Image
    {
        set
        {
            _imageItem = value;
        }
    }

    public string GalleryName
    {
        set
        {
            _galleryName = value.Replace(" ", "");
        }
    }

    public int ThumbnailWidth
    {
        set
        {
            _thumbnailWidth = value;
        }
    }
}
