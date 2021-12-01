/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageEdgeDetection
{
    public partial class MainForm : Form
    {

        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private LoadImageService loadImage;
       
        
        public MainForm()
        {
            InitializeComponent();          
        }


        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {

            loadImage = new LoadImageService();

            originalBitmap = loadImage.LoadImage();  
            
            previewBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
            picPreview.Image = previewBitmap;

            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void btnSaveNewImage_Click(object sender, EventArgs e)
        {

            if (picPreview.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    picPreview.Image.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();

                    picPreview.Image = null;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    groupBox4.Enabled = false;
                }
            }
        }

        private void BandWFilterButton_Click(object sender, EventArgs e)
        {
            picPreview.Image = ImageFilters.BlackWhite(new Bitmap(picPreview.Image));
            previewBitmap = (Bitmap)picPreview.Image;
            groupBox3.Enabled = true;
        }

        private void RainbowFilterButton_Click(object sender, EventArgs e)
        {
            picPreview.Image = ImageFilters.RainbowFilter(new Bitmap(picPreview.Image));
            previewBitmap = (Bitmap)picPreview.Image;
            groupBox3.Enabled = true;
        }

        private void EdgeDetectionButton_Click(object sender, EventArgs e)
        {

            if (listBoxXFilter.SelectedItem != null && listBoxYFilter.SelectedItem !=null)
            {
                labelErrors.Text = "";
                picPreview.Image=ImageEdge.filter(listBoxXFilter.SelectedItem.ToString(), listBoxYFilter.SelectedItem.ToString(), previewBitmap);
                groupBox4.Enabled = true;
            }
            else
            {
                labelErrors.Text = "2 filters must be selected";
            }
        }

  

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void listBoxXFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
