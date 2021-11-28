using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ImageEdgeDetection
{
    public static class ImageEdge
    {
        public static Bitmap filter(string xfilter, string yfilter, Bitmap previewBitmap)
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
            return resultbitmap;
        }
    }
}
