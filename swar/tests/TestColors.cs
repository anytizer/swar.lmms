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
            
            Coloring first = cr.getNextColor();
            Coloring second = cr.getNextColor();
            Coloring third = cr.getNextColor();
            Coloring fourth = cr.getNextColor();
            Coloring fifth = cr.getNextColor();
            Coloring sixth = cr.getNextColor();

            Coloring seventh = cr.getNextColor();

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
