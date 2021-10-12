using configs;
using dtos;
using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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
    }
}
