using dtos;
using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class TestSignature
    {
        [TestMethod]
        public void BeatNominatorParser()
        {
            string _beat = "2/4";

            int nominator = Helpers.ParseNominator(_beat);

            Assert.IsTrue(nominator == 2);        }

        [TestMethod]
        public void BeatDenominatorParser()
        {
            string _beat = "3/4";

            int denominator = Helpers.ParseDenominator(_beat);

            Assert.IsTrue(denominator == 4);
        }

        [TestMethod]
        public void TempoParser()
        {
            int tempo = Helpers.ParseTempo("280");

            Assert.IsTrue(tempo == 280);
        }

        [TestMethod]
        public void SignatureParser()
        {
            string filename = "notations-sargams-3-4-280.txt";
            Signature s = Helpers.SignatureFromFilename(filename);

            Assert.AreEqual(3, s.beat_nominator);
            Assert.AreEqual(4, s.beat_denominator);
            Assert.AreEqual(280, s.tempo);
        }
    }
}
