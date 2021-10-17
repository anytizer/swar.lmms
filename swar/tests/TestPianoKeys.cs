using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class TestPianoKeys
    {
        [TestMethod]
        public void TestKeyG9()
        {
            string key = "G*****"; // G9

            PianoKeys pk = new PianoKeys();
            int G9 = pk.getPianoKey(key);

            Assert.AreEqual(127, G9);
        }

        [TestMethod]
        public void TestKeyCSharp()
        {
            string key = "C#"; // C4#

            PianoKeys pk = new PianoKeys();
            int CSharp = pk.getPianoKey(key);

            Assert.AreEqual(61, CSharp);
        }

        [TestMethod]
        public void TestKeyC3()
        {
            string key = "C."; // C3

            PianoKeys pk = new PianoKeys();
            int C3 = pk.getPianoKey(key);

            Assert.AreEqual(48, C3);
        }

        [TestMethod]
        public void TestKeyCMinusOne()
        {
            string key = "C....."; // C-1

            PianoKeys pk = new PianoKeys();
            int CMinusOne = pk.getPianoKey(key);

            Assert.AreEqual(0, CMinusOne);
        }
    }
}
