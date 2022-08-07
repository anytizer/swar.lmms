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

                File.WriteAllText(string.Format("{0}/swar-{1,2}.xpt", path, sequence.ToString("00")), xpt);
            }

            File.WriteAllText(string.Format("{0}/{1}", path, EnglishNotationsFile), scales);
        }

        public bool DeleteXPTs()
        {
            string[] XPTs = new[] {
                "swar-00.xpt",
                "swar-01.xpt",
                "swar-02.xpt",
                "swar-03.xpt",
                "swar-04.xpt",
                "swar-05.xpt",
                "swar-06.xpt",
                "swar-07.xpt",
                "swar-08.xpt",
                "swar-09.xpt",
                "swar-10.xpt",
                "swar-11.xpt",
                "swar-12.xpt",
                "swar-13.xpt",
                "swar-14.xpt",
                "swar-15.xpt",
                "swar-16.xpt",
                "swar-17.xpt",
                "swar-18.xpt",
                "swar-19.xpt",
                "swar-20.xpt",
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
