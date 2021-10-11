using libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    class TestHelpers
    {

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
            string fullpath = "d:/projects/title1/notations-english.txt";
            string title = Helpers.SongTitle(fullpath);

            Assert.IsTrue(title == "title1");
        }
    }
}
