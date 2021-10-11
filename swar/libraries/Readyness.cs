using configs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraries
{
    public class Readyness
    {
        string path;

        public Readyness()
        {
            this.path = Configurations.ReadWriteDirectory;
        }

        public bool DeleteEnglishNotations()
        {
            if(File.Exists(path + "/notations-english.txt"))
            {
                File.Delete(path + "/notations-english.txt");
            }
            
            return DeleteEnglishNotations();
        }

        public bool DeleteSargamsNotations()
        {
            if (File.Exists(path + "/notations-sargams.txt"))
            {
                File.Delete(path + "/notations-sargams.txt");
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

            File.WriteAllText(string.Format("{0}/notations-english.txt", path), scales);
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
            };

            foreach(string xptfile in XPTs)
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
            return File.Exists(path + "/notations-sargams.txt");
        }

        public bool EnglishNotationsExist()
        {
            return File.Exists(path + "/notations-english.txt");
        }
    }
}
