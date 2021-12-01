using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ImageEdgeDetection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageEdgeDetectionUnitTest
{
    [TestClass]
    public class FilterTest
    {
        [TestMethod]
        public void TestBlackAndWhiteFilter()
        {
            //base
            Bitmap basePicture = new Bitmap(@"..\\..\\Images\\mario-base.png");
            string resultImageAfterFilter_REF;
            string resultSavedBitmap_REF;

            //action
            Bitmap resultImageAfterFilter = ImageFilters.BlackWhite(basePicture);
            Bitmap resultSavedBitmap = new Bitmap(@"..\\..\\Images\\mario-blackwhite2.png");

            //Assert
            if (resultImageAfterFilter.Width == resultSavedBitmap.Width && resultImageAfterFilter.Height == resultSavedBitmap.Height)
            {
                for (int i = 0; i < resultImageAfterFilter.Width; i++)
                {
                    for (int j = 0; j < resultImageAfterFilter.Height; j++)
                    {
                        resultImageAfterFilter_REF = resultImageAfterFilter.GetPixel(i, j).ToString();
                        resultSavedBitmap_REF = resultSavedBitmap.GetPixel(i, j).ToString();

                        Assert.AreEqual(resultImageAfterFilter_REF, resultSavedBitmap_REF);
                    }
                }
            }
        }

        [TestMethod]
        public void TestBlackAndWhiteFilterSimpleImage()
        {
            //base
            Bitmap basePicture = new Bitmap(@"..\\..\\Images\\discussion_1.png");
            string resultImageAfterFilter_REF;
            string resultSavedBitmap_REF;

            //action
            Bitmap resultImageAfterFilter = ImageFilters.BlackWhite(basePicture);
            Bitmap resultSavedBitmap = new Bitmap(@"..\\..\\Images\\discussion_1_bw.png");

            //Assert
            if (resultImageAfterFilter.Width == resultSavedBitmap.Width && resultImageAfterFilter.Height == resultSavedBitmap.Height)
            {
                for (int i = 0; i < resultImageAfterFilter.Width; i++)
                {
                    for (int j = 0; j < resultImageAfterFilter.Height; j++)
                    {
                        resultImageAfterFilter_REF = resultImageAfterFilter.GetPixel(i, j).ToString();
                        resultSavedBitmap_REF = resultSavedBitmap.GetPixel(i, j).ToString();

                        Assert.AreEqual(resultImageAfterFilter_REF, resultSavedBitmap_REF);
                    }
                }
            }
        }


        [TestMethod]
        public void TestRainbowFilter()
        {
            //base
            Bitmap basePicture = new Bitmap(@"..\\..\\Images\\mario-base.png");
            string resultImageAfterFilter_REF;
            string resultSavedBitmap_REF;

            //action
            Bitmap resultImageAfterFilter = ImageFilters.RainbowFilter(basePicture);
            Bitmap resultSavedBitmap = new Bitmap(@"..\\..\\Images\\mario-rainbow.png");

            //Assert
            if (resultImageAfterFilter.Width == resultSavedBitmap.Width && resultImageAfterFilter.Height == resultSavedBitmap.Height)
            {
                for (int i = 0; i < resultImageAfterFilter.Width; i++)
                {
                    for (int j = 0; j < resultImageAfterFilter.Height; j++)
                    {
                        resultImageAfterFilter_REF = resultImageAfterFilter.GetPixel(i, j).ToString();
                        resultSavedBitmap_REF = resultSavedBitmap.GetPixel(i, j).ToString();

                        Assert.AreEqual(resultImageAfterFilter_REF, resultSavedBitmap_REF);
                    }
                }
            }
        }

        [TestMethod]
        public void TestRainbowFilterSimpleImage()
        {
            //base
            Bitmap basePicture = new Bitmap(@"..\\..\\Images\\discussion_1.png");
            string resultImageAfterFilter_REF;
            string resultSavedBitmap_REF;

            //action
            Bitmap resultImageAfterFilter = ImageFilters.RainbowFilter(basePicture);
            Bitmap resultSavedBitmap = new Bitmap(@"..\\..\\Images\\discussion_rainbow.png");

            //Assert
            if (resultImageAfterFilter.Width == resultSavedBitmap.Width && resultImageAfterFilter.Height == resultSavedBitmap.Height)
            {
                for (int i = 0; i < resultImageAfterFilter.Width; i++)
                {
                    for (int j = 0; j < resultImageAfterFilter.Height; j++)
                    {
                        resultImageAfterFilter_REF = resultImageAfterFilter.GetPixel(i, j).ToString();
                        resultSavedBitmap_REF = resultSavedBitmap.GetPixel(i, j).ToString();

                        Assert.AreEqual(resultImageAfterFilter_REF, resultSavedBitmap_REF);
                    }
                }
            }
        }
    }
}
