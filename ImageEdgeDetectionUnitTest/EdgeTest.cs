using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageEdgeDetection;
using System.Drawing;


namespace ImageEdgeDetectionUnitTest
{
    [TestClass]
    public class EdgeTest
    {

        [TestMethod]
        public void TestLaplacian_Kirsh()
        {
            //base
            Bitmap basePicture = new Bitmap(@"..\\..\\Images\\mario-base.png");
            string resultImageAfterFilter_REF;
            string resultSavedBitmap_REF;

            //action
            Bitmap resultImageAfterFilter = ImageEdge.filter("Laplacian3x3", "Kirsch3x3Vertical", basePicture);
            Bitmap resultSavedBitmap = new Bitmap(@"..\\..\\Images\\mario-laplacian3x3-kirsh3x3vertical.png");

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
        public void TestSobel_Prewitt()
        {
            //base
            Bitmap basePicture = new Bitmap(@"..\\..\\Images\\mario-base.png");
            string resultImageAfterFilter_REF;
            string resultSavedBitmap_REF;

            //action
            Bitmap resultImageAfterFilter = ImageEdge.filter("Sobel3x3Horizontal", "Prewitt3x3Horizontal", basePicture);
            Bitmap resultSavedBitmap = new Bitmap(@"..\\..\\Images\\mario-sobel3x3hori-prewitt3x3hori.png");

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
        public void TestSobel_Sobel()
        {
            //base
            Bitmap basePicture = new Bitmap(@"..\\..\\Images\\mario-base.png");
            string resultImageAfterFilter_REF;
            string resultSavedBitmap_REF;

            //action
            Bitmap resultImageAfterFilter = ImageEdge.filter("Sobel3x3Horizontal", "Sobel3x3Vertical", basePicture);
            Bitmap resultSavedBitmap = new Bitmap(@"..\\..\\Images\\mario-sobel3x3hori-sobel3x3verti.png");

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
