using configs;
using dtos;
using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace tests
{
    [TestClass]
    public class TestGeneral
    {
        [TestMethod]
        public void TestName()
        {
            Assert.IsTrue(Configurations.name == "SWAR");
        }

        [TestMethod]
        public void TestVersion()
        {
            Assert.IsTrue(Configurations.version == "0.0.1");
        }

        [TestMethod]
        public void TestCanWriteToConfigurationDirectory()
        {
            Assert.IsTrue(Directory.Exists(Configurations.ReadWriteDirectory));
        }

        [TestMethod]
        public void TestCountSubdirectories()
        {
            string[] di = Directory.GetDirectories(Configurations.ReadWriteDirectory);
            // parser
            // .git
            Assert.IsTrue(di.Length == 2);
        }
    }
}
