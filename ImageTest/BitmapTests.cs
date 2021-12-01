using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageEdgeDetection;
using System.Drawing;
using System;

namespace ImageTest
{
    [TestClass]
    public class BitmapTests
    {

        [TestMethod]
        public void GetBitmapLoad_NoFileLoad()
        {

            var service = new LoadImageService();

            FakeBitmapReader fbr = new FakeBitmapReader();

            /* FakeBitmapReader fakeRead = new FakeBitmapReader();
             var result = fakeRead.GetImage(); */

            var result = fbr.LoadImage();

        
                    
        }

        
    }
}
