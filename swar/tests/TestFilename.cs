using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    [TestClass]
    public class TestFilename
    {
        [TestMethod]
        public void filename()
        {
            string filename = ".\\swar.xpt";

            string name = System.IO.Path.GetFileName(filename);
            Assert.AreEqual("swar.xpt", name);
        }
    }
}
