using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageEdgeDetection
{
    public class LoadImageService 
    {

        public IImageRepository ImageRepository { get; set; }

        public LoadImageService()
        {
            ImageRepository = new ImageRepository();
        }

        public Bitmap LoadImage()
        {
            return ImageRepository.GetImage();  
        }


    }
}
