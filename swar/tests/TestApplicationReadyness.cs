using dtos;
using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    public class TestApplicationReadyness
    {

        [TestMethod]
        public void TestApplicationSystemConverts()
        {
            ApplicationSystem s = new ApplicationSystem();
            Readyness r = new Readyness();

            r.DeleteXPTs();

            r.DeleteSargamsNotations();
            //Assert.IsFalse(r.SargamsNotationsExist());

            r.DeleteEnglishNotations();
            //Assert.IsFalse(r.EnglishNotationsExist());

            string sargams = "sa*'";
            Signature signature = new Signature(3, 4, 280);

            string scales = s.convert(sargams, signature);
            Assert.AreEqual("1: C#", scales.Trim());

            Assert.IsTrue(r.SargamsNotationsExist());
            Assert.IsTrue(r.EnglishNotationsExist());
        }

        [TestMethod]
        public void ConvertScales()
        {
            ApplicationSystem s = new ApplicationSystem();

            string sargams = "sa";
            Signature signature = new Signature(3, 4, 280);

            string scales = s.convert(sargams, signature);
            Assert.AreEqual("1: C", scales.Trim());
        }
    }
}
