using configs;
using dtos;
using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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

        [TestMethod]
        public void HelperConvertsTitleFromSargamNotations()
        {
            string fullpath = "d:/projects/title/notations/notations-sargams.txt";
            string title = Helpers.SongTitle(fullpath);
            
            Assert.IsTrue(title == "title");
        }

        [TestMethod]
        public void HelperConvertsTitleFromEnglishNotations()
        {
            string fullpath = "d:/projects/title1/notations/notations-english.txt";
            string title = Helpers.SongTitle(fullpath);

            Assert.IsTrue(title == "title1");
        }

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

            string sargams = "sa*";
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
            Assert.AreEqual("1: C", scales.Trim()); // line numbers are prepended
        }

        [TestMethod]
        public void TestColors()
        {
            ColorsRotator cr = new ColorsRotator();
            
            Color first = cr.getColor();
            Color second = cr.getColor();
            Color third = cr.getColor();
            Color forth = cr.getColor();
            Color fifth = cr.getColor();
            Color sixth = cr.getColor();
            Color seventh = cr.getColor();

            Assert.AreEqual("green", first.name);
            Assert.AreEqual("pink", second.name);
            Assert.AreEqual("red", third.name);
            Assert.AreEqual("yellow", forth.name);
            Assert.AreEqual("blue", fifth.name);
            Assert.AreEqual("gold", sixth.name);

            Assert.AreEqual("green", seventh.name);
        }
    }
}
