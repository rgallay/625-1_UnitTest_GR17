using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageEdgeDetection
{
    public class ImageRepository : IImageRepository
    {
        public Bitmap image = null;

        public Bitmap GetImage()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                image = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();
            }

            return image;

        }



    }
}
