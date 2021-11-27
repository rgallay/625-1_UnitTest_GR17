using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageEdgeUnitTest
{
    [TestClass]
    public class FilterTest
    {
        [TestMethod]
        public void TestBlackAndWhiteFilter()
        {
            //base
            Bitmap basePicture = new Bitmap("C:\\Users\\rgall\\Documents\\HES-IG\\Semestre7\\625-1 Software Validation\\ImageDetectionGR17\\C#\\ImageEdgeDetectionUnitTest\\images\\mario-base.png");
            string resultImageAfterFilter_REF;
            string resultSavedBitmap_REF;

            //action
            Bitmap resultImageAfterFilter = ImageFilters.BlackWhite(basePicture);
            Bitmap resultSavedBitmap = new Bitmap("C:\\Users\rgall\\Documents\\HES-IG\\Semestre7\\625-1 Software Validation\\ImageDetectionGR17\\C#\\ImageEdgeDetectionUnitTest\\images\\mario-blackwhite.png");

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
        }
    }
}
