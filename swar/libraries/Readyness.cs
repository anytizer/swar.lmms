using configs;
using System.Collections.Generic;
using System.IO;

namespace libraries
{
    public class Readyness
    {
        private string path;
        private string SargamsNotationsFile; // sa re ga ma, ...
        private string UnicodeNotationsFile; // प़ सा रेसा  ध़प़, ... 
        private string EnglishNotationsFile; // C, D, E, F, G, A, B

        public Readyness()
        {
            this.path = Configurations.ReadWriteDirectory;
            this.SargamsNotationsFile = "notations-sargams.txt";
            this.UnicodeNotationsFile = "notations-unicode.txt";
            this.EnglishNotationsFile = "notations-english.txt";
        }

        public bool DeleteUnicodeNotations()
        {
            if (File.Exists(path + "/" + UnicodeNotationsFile))
            {
                File.Delete(path + "/" + UnicodeNotationsFile);
            }

            return UnicodeNotationsExist();
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
                "lmms-00.xpt",
                "lmms-01.xpt",
                "lmms-02.xpt",
                "lmms-03.xpt",
                "lmms-04.xpt",
                "lmms-05.xpt",
                "lmms-06.xpt",
                "lmms-07.xpt",
                "lmms-08.xpt",
                "lmms-09.xpt",
                "lmms-10.xpt",
                "lmms-11.xpt",
                "lmms-12.xpt",
                "lmms-13.xpt",
                "lmms-14.xpt",
                "lmms-15.xpt",
                "lmms-16.xpt",
                "lmms-17.xpt",
                "lmms-18.xpt",
                "lmms-19.xpt",
                "lmms-20.xpt",
            };

            foreach (string xptfile in XPTs)
            {
                string file = path + "/" + xptfile;
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }

            return false;
        }

        public bool SargamsNotationsExist()
        {
            return this.notationFileExists(SargamsNotationsFile);
        }

        public bool EnglishNotationsExist()
        {
            return this.notationFileExists(EnglishNotationsFile);
        }

        public bool UnicodeNotationsExist()
        {
            return this.notationFileExists(UnicodeNotationsFile);
        }

        private bool notationFileExists(string filename="/tmp/file.txt")
        {
            // @todo Convert filename to basename
            bool exists = File.Exists(path + "/" + filename);
            return exists;
        }
    }
}
