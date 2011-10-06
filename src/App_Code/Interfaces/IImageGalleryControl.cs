using System;

/// <summary>
/// Summary description for IImageGalleryControl
/// </summary>
public interface IImageGalleryControl
{
    ImageGalleryItem ImageGallery
    {
        set;
    }

    bool ShowTitle
    {
        set;
    }
}
