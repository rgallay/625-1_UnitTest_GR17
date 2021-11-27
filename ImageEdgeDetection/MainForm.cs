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
                filter(listBoxXFilter.SelectedItem.ToString(), listBoxYFilter.SelectedItem.ToString());
                groupBox4.Enabled = true;
            }
            else
            {
                labelErrors.Text = "2 filters must be selected";
            }
        }

        public void filter(string xfilter, string yfilter)
        {
            double[,] xFilterMatrix;
            double[,] yFilterMatrix;
            switch (xfilter)
            {
                case "Laplacian3x3":
                    xFilterMatrix = Matrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    xFilterMatrix = Matrix.Laplacian5x5;
                    break;
                case "LaplacianOfGaussian":
                    xFilterMatrix = Matrix.LaplacianOfGaussian;
                    break;
                case "Gaussian3x3":
                    xFilterMatrix = Matrix.Gaussian3x3;
                    break;
                case "Gaussian5x5Type1":
                    xFilterMatrix = Matrix.Gaussian5x5Type1;
                    break;
                case "Gaussian5x5Type2":
                    xFilterMatrix = Matrix.Gaussian5x5Type2;
                    break;
                case "Sobel3x3Horizontal":
                    xFilterMatrix = Matrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    xFilterMatrix = Matrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    xFilterMatrix = Matrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    xFilterMatrix = Matrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    xFilterMatrix = Matrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    xFilterMatrix = Matrix.Kirsch3x3Vertical;
                    break;
                default:
                    xFilterMatrix = Matrix.Laplacian3x3;
                    break;
            }

            switch (yfilter)
            {
                case "Laplacian3x3":
                    yFilterMatrix = Matrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    yFilterMatrix = Matrix.Laplacian5x5;
                    break;
                case "LaplacianOfGaussian":
                    yFilterMatrix = Matrix.LaplacianOfGaussian;
                    break;
                case "Gaussian3x3":
                    yFilterMatrix = Matrix.Gaussian3x3;
                    break;
                case "Gaussian5x5Type1":
                    yFilterMatrix = Matrix.Gaussian5x5Type1;
                    break;
                case "Gaussian5x5Type2":
                    yFilterMatrix = Matrix.Gaussian5x5Type2;
                    break;
                case "Sobel3x3Horizontal":
                    yFilterMatrix = Matrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    yFilterMatrix = Matrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    yFilterMatrix = Matrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    yFilterMatrix = Matrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    yFilterMatrix = Matrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    yFilterMatrix = Matrix.Kirsch3x3Vertical;
                    break;
                default:
                    yFilterMatrix = Matrix.Laplacian3x3;
                    break;
            }

            if (picPreview.Image.Size.Height > 0)
            {
                Bitmap newbitmap = new Bitmap(previewBitmap);
                BitmapData newbitmapData = new BitmapData();
                newbitmapData = newbitmap.LockBits(new Rectangle(0, 0, newbitmap.Width, newbitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

                byte[] pixelbuff = new byte[newbitmapData.Stride * newbitmapData.Height];
                byte[] resultbuff = new byte[newbitmapData.Stride * newbitmapData.Height];

                Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
                newbitmap.UnlockBits(newbitmapData);

                double blueX;
                double greenX;
                double redX;

                double blueY;
                double greenY;
                double redY;

                double blueTotal;
                double greenTotal;
                double redTotal;

                int filterOffset = 1;
                int calcOffset;

                int byteOffset;

                for (int offsetY = filterOffset; offsetY <
                    newbitmap.Height - filterOffset; offsetY++)
                {
                    for (int offsetX = filterOffset; offsetX <
                        newbitmap.Width - filterOffset; offsetX++)
                    {
                        blueX = greenX = redX = 0;
                        blueY = greenY = redY = 0;

                        blueTotal = greenTotal = redTotal = 0.0;

                        byteOffset = offsetY *
                                     newbitmapData.Stride +
                                     offsetX * 4;

                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {
                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                             (filterY * newbitmapData.Stride);

                                blueX += (double)(pixelbuff[calcOffset]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenX += (double)(pixelbuff[calcOffset + 1]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redX += (double)(pixelbuff[calcOffset + 2]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                blueY += (double)(pixelbuff[calcOffset]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenY += (double)(pixelbuff[calcOffset + 1]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redY += (double)(pixelbuff[calcOffset + 2]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];
                            }
                        }

                        blueTotal = 0;
                        greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                        redTotal = 0;

                        if (blueTotal > 255)
                        { blueTotal = 255; }
                        else if (blueTotal < 0)
                        { blueTotal = 0; }

                        if (greenTotal > 255)
                        { greenTotal = 255; }
                        else if (greenTotal < 0)
                        { greenTotal = 0; }

                        if (redTotal > 255)
                        { redTotal = 255; }
                        else if (redTotal < 0)
                        { redTotal = 0; }

                        resultbuff[byteOffset] = (byte)(blueTotal);
                        resultbuff[byteOffset + 1] = (byte)(greenTotal);
                        resultbuff[byteOffset + 2] = (byte)(redTotal);
                        resultbuff[byteOffset + 3] = 255;
                    }
                }

                Bitmap resultbitmap = new Bitmap(newbitmap.Width, newbitmap.Height);

                BitmapData resultData = resultbitmap.LockBits(new Rectangle(0, 0,
                                         resultbitmap.Width, resultbitmap.Height),
                                                          ImageLockMode.WriteOnly,
                                                      PixelFormat.Format32bppArgb);

                Marshal.Copy(resultbuff, 0, resultData.Scan0, resultbuff.Length);
                resultbitmap.UnlockBits(resultData);
                picPreview.Image = resultbitmap;
            }
            else
            {
                labelErrors.Text = "You must load an image";
            }
        }

    }
}
