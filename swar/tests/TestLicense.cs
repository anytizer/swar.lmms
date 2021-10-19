using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class TestLicense
    {
        [TestMethod]
        public void TestLicenseMode()
        {
            License license = new License();
            int mode = license.mode();

            Assert.AreEqual(100, mode);
        }
    }
}
