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

public partial class Controls_FeatureImagesRotator : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        
         string featureImagesGalleryName = ConfigurationManager.AppSettings["FeatureImagesGalleryName"];
        IList<ContentItem> resultList = N2.Find.Items.
                Where.Name.Eq(featureImagesGalleryName)
                .Select();

        if (resultList.Count > 0)
        {
            ImageGalleryItem gallery = (ImageGalleryItem)resultList[0];


            N2.Collections.ItemFilter imagesFilter = new N2.Collections.TypeFilter(typeof(ImageItem));
            N2.Collections.ItemList imageItems = gallery.GetChildren(imagesFilter);
            
            FeatureImagesRotator.ScrollDuration = Convert.ToInt32(ConfigurationManager.AppSettings["FeatureImagesRotateTime"]) * 1000;
            FeatureImagesRotator.DataSource = imageItems;
            FeatureImagesRotator.DataBind();

        }
    }

   
}

