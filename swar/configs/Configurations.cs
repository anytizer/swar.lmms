using System.Collections.Generic;
using System.IO;
using System.Text;

namespace configs
{
    public static class Configurations
    {
        public const string name = "SWAR";
        public const string version = "0.0.1";

        // Directory MUST exist
        public const string ReadWriteDirectory = "d:/projects/lmms.xpt";

        public static List<string> sargams()
        {
            List<string> sargams = new List<string>();

            string[] lines = File.ReadAllLines(ReadWriteDirectory + "/sargams.txt", Encoding.UTF8);
            foreach (string _line in lines)
            {
                string line = _line.Trim();
                if (line != "" && !line.StartsWith(SpecialKeys.HASH) && File.Exists(line))
                {
                    sargams.Add(line);
                }
            }

            return sargams;
        }
    }
}
