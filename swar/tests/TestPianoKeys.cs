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
        public void TestKeyGShap4()
        {
            string key = "G'"; // G#4

            PianoKeys pk = new PianoKeys();
            int GShap4 = pk.getPianoKey(key);

            Assert.AreEqual(60+8, GShap4);
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
        public void TestKeyC5Sharp()
        {
            string key = "C#*"; // C#5

            PianoKeys pk = new PianoKeys();
            int CSharp = pk.getPianoKey(key);

            Assert.AreEqual(72, CSharp);
        }

        [TestMethod]
        public void TestKeyC5thSharp()
        {
            string key = "C'*"; // C#5

            PianoKeys pk = new PianoKeys();
            int CSharp = pk.getPianoKey(key);

            Assert.AreEqual(72, CSharp);
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
