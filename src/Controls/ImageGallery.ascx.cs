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

public partial class Controls_ImageGallery : System.Web.UI.UserControl, IImageGalleryControl
{
    private ImageGalleryItem _imageGallery;
    private bool _showTitle = true;

   protected void Page_Load(object sender, EventArgs e)
    {
        BindGallery();
        
    }

    private void BindGallery()
    {

        if (_showTitle)
        {
            if (_imageGallery.LinkFromHeader)
            {
                string urlFormat = "<a class=\"nodecoration\" href=\"{0}\">{1}</a>";
                GalleryTitleLiteral.Text = string.Format(urlFormat, _imageGallery.Url,_imageGallery.Title);
            }
            else
            {
                GalleryTitleLiteral.Text = _imageGallery.Title;
            }

            GalleryTitlePanel.Visible = true;
            if (_imageGallery.Teaser != string.Empty)
            {
                GalleryTeaserLiteral.Text = _imageGallery.Teaser;
            }
        }
        else if (!_imageGallery.ShowImages)
        {
            GalleryPanel.Visible = false;
        }

        N2.Collections.ItemFilter imagesFilter = new N2.Collections.TypeFilter(typeof(ImageItem));
        N2.ContentItem imageFolderItem = GetImageFolderItem(_imageGallery);
         N2.Collections.ItemList imageItems = null;
         if (imageFolderItem != null)
         {
             imageItems = imageFolderItem.GetChildren(imagesFilter);
         }
         else
         {
             imageItems = _imageGallery.GetChildren(imagesFilter);
         }

        if (imageItems.Count > 0)
        {
            BuildTable(imageItems);

        }
    }

    private N2.ContentItem GetImageFolderItem(N2.ContentItem imageGalleryItem)
    {
       IList<N2.ContentItem> imageFolderItemsList = N2.Find.Items.Where.Name.Eq("Images")
           .And.Type.Eq(typeof(FolderItem))
           .And.Parent.Eq(imageGalleryItem).Select();

        if (imageFolderItemsList.Count >0){
            return imageFolderItemsList[0];
        }
        else return null;
    }

    private void BuildTable( N2.Collections.ItemList imageItems)
    {
        TableRow tableRow = null;

        for (int i = 0; i < imageItems.Count; ++i)
        {
            if (i % _imageGallery.Columns == 0)
            {
               tableRow = new TableRow();
               GalleryTable.Rows.Add(tableRow);
            }

            IImageControl imageControl = (IImageControl)LoadControl("~/Controls/Image.ascx");
            imageControl.Image = (ImageItem)imageItems[i];
            imageControl.GalleryName = _imageGallery.Title;
            imageControl.ThumbnailWidth = _imageGallery.ThumbnailWidth;

            TableCell tableCell = new TableCell();
            tableCell.CssClass = "gallery_image";
            tableCell.Controls.Add((Control)imageControl);

            tableRow.Cells.Add(tableCell);
        }
    }

    public ImageGalleryItem ImageGallery
    {
        set
        {
            _imageGallery = value;
        }
    }

    public bool ShowTitle
    {
        set
        {
            _showTitle = value;
        }
    }
}
