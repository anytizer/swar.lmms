using configs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace tests
{
    [TestClass]
    public class TestConfigurations
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
            // @todo can read write
            Assert.IsTrue(Directory.Exists(Configurations.ReadWriteDirectory));
        }

        [TestMethod]
        public void TestCountSubdirectories()
        {
            string[] dirs = Directory.GetDirectories(Configurations.ReadWriteDirectory);
            // parsers
            // .git
            Assert.IsTrue(dirs.Length == 2);
        }
    }
}
