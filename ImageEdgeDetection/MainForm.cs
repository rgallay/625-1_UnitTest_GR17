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
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();

                previewBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                picPreview.Image = previewBitmap;

                //set groupbox to false when load image except the second one
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
            }
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

                    //set groupbox to false: waiting another image
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

    }
}
