using configs;
using System.Collections.Generic;
using System.IO;

namespace libraries
{
    public class Readyness
    {
        private string path;
        private string SargamsNotationsFile;
        private string EnglishNotationsFile;

        public Readyness()
        {
            this.path = Configurations.ReadWriteDirectory;
            this.SargamsNotationsFile = "notations-sargams.txt";
            this.EnglishNotationsFile = "notations-english.txt";
        }

        public bool DeleteEnglishNotations()
        {
            if (File.Exists(path + "/" + EnglishNotationsFile))
            {
                File.Delete(path + "/" + EnglishNotationsFile);
            }

            return EnglishNotationsExist();
        }

        public bool DeleteSargamsNotations()
        {
            if (File.Exists(path + "/" + SargamsNotationsFile))
            {
                File.Delete(path + "/" + SargamsNotationsFile);
            }

            return SargamsNotationsExist();
        }

        internal void write(string scales, List<string> xpts)
        {
            int sequence = 0;
            foreach (string xpt in xpts)
            {
                ++sequence;

                File.WriteAllText(string.Format("{0}/lmms-{1,2}.xpt", path, sequence.ToString("00")), xpt);
            }

            File.WriteAllText(string.Format("{0}/{1}", path, EnglishNotationsFile), scales);
        }

        public bool DeleteXPTs()
        {
            string[] XPTs = new[] {
                path + "/lmms-00.xpt",
                path + "/lmms-01.xpt",
                path + "/lmms-02.xpt",
                path + "/lmms-03.xpt",
                path + "/lmms-04.xpt",
                path + "/lmms-05.xpt",
                path + "/lmms-06.xpt",
                path + "/lmms-07.xpt",
                path + "/lmms-08.xpt",
                path + "/lmms-09.xpt",
                path + "/lmms-10.xpt",
            };

            foreach (string xptfile in XPTs)
            {
                if (File.Exists(xptfile))
                {
                    File.Delete(xptfile);
                }
            }

            return false;
        }

        public bool SargamsNotationsExist()
        {
            return File.Exists(path + "/" + SargamsNotationsFile);
        }

        public bool EnglishNotationsExist()
        {
            return File.Exists(path + "/" + EnglishNotationsFile);
        }
    }
}
