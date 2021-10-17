using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class TestSignature
    {
        [TestMethod]
        public void BeatParser()
        {
            string _beat = "2/4";

            int nominator = Helpers.ParseNominator(_beat);
            int denominator = Helpers.ParseDenominator(_beat);

            Assert.IsTrue(nominator == 2);
            Assert.IsTrue(denominator == 4);
        }

        [TestMethod]
        public void TempoParser()
        {
            int tempo = Helpers.ParseTempo("280");

            Assert.IsTrue(tempo == 280);
        }
    }
}
