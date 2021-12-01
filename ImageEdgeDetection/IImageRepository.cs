using System.Drawing;

namespace ImageEdgeDetection
{
    public interface IImageRepository
    {
        Bitmap GetImage();
    }
}