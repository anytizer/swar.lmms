using dtos;
using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class TestColors
    {
        [TestMethod]
        public void TestColorRotation()
        {
            ColorsRotator cr = new ColorsRotator();
            
            Color first = cr.getNextColor();
            Color second = cr.getNextColor();
            Color third = cr.getNextColor();
            Color fourth = cr.getNextColor();
            Color fifth = cr.getNextColor();
            Color sixth = cr.getNextColor();

            Color seventh = cr.getNextColor();

            Assert.AreEqual("green", first.name);
            Assert.AreEqual("pink", second.name);
            Assert.AreEqual("blue", third.name);
            Assert.AreEqual("yellow", fourth.name);
            Assert.AreEqual("gold", fifth.name);
            Assert.AreEqual("red", sixth.name);
            
            // repeat!
            Assert.AreEqual("green", seventh.name);
        }
    }
}
