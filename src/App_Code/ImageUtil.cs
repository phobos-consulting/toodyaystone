using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text;
using System.IO;


	/// <summary>
	/// Summary description for ImageBuilder.
	/// </summary>
public class ImageUtil
{

    
    
    public static string GetThumbnailUrl(string imagePath, string thumbExt, string thumbFolderUrl)
    {
        string imageNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(imagePath);
        return thumbFolderUrl + "/" + imageNameWithoutExt + thumbExt + ".jpg";
    }


   
   
    public static void AddThumbnail(string imagePath, int width, string fileNameAddition, string fileSavePath)
    {
        bool renameImage = true;
        string savePath = "";
        try
        {
        System.IO.Stream imageStream = File.Open(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        try
        {
        string imageNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(imagePath);
        
        savePath = fileSavePath.TrimEnd('\\') + "\\" + imageNameWithoutExt;
        savePath += fileNameAddition;
        savePath += ".jpg";


        if (!File.Exists(savePath))
        {

            System.Drawing.Image mg = System.Drawing.Image.FromStream(imageStream, true);

            double multiplier = (double)width / mg.Width;
            int newWidth = width;
            int newHeight = (int)(mg.Height * multiplier);

           Size newSize = new Size(newWidth, newHeight);

            Bitmap bp = new Bitmap(newSize.Width, newSize.Height);

            Graphics g = Graphics.FromImage(bp);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rect = new Rectangle(0, 0, newSize.Width, newSize.Height);
            g.DrawImage(mg, rect, 0, 0, mg.Width, mg.Height, GraphicsUnit.Pixel);

            foreach (PropertyItem pItem in mg.PropertyItems)
            {
                bp.SetPropertyItem(pItem);
            }

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo codec = null;
            for (int i = 0; i < codecs.Length; i++)
            {
                if (codecs[i].MimeType.Equals("image/jpeg"))
                    codec = codecs[i];
            }

            if (codec != null)
            {
                EncoderParameters encoderParameters = new EncoderParameters(2);

                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameter encoderParameter = new EncoderParameter(encoder, 95L);
                encoderParameters.Param[0] = encoderParameter;

                encoder = System.Drawing.Imaging.Encoder.ColorDepth;
                encoderParameter = new EncoderParameter(encoder, 100L);
                encoderParameters.Param[1] = encoderParameter;

                bp.Save(savePath, codec, encoderParameters);

            }


        }
        }
        catch
        {
            renameImage = false;
        }
        finally
        {
            imageStream.Close();
        }
        }
        catch
        {
            //Could not open image
        }

        //if (insituResize && renameImage && savePath != "")
        //{
        //    System.IO.File.Delete(imagePath);
        //    System.IO.File.Move(savePath, imagePath);
        //}

    }

   



}
