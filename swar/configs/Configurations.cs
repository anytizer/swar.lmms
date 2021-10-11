using System.Collections.Generic;
using System.IO;
using System.Text;

namespace configs
{
    public static class Configurations
    {
        public static string name = "SWAR";
        public static string version = "0.0.1";

        // Directory MUST exist
        public static string ReadWriteDirectory = "d:/desktop/xpt";

        public static List<string> sargams()
        {
            List<string> sargams = new List<string>();

            string[] lines = File.ReadAllLines(ReadWriteDirectory + "/sargams.txt", Encoding.UTF8);
            foreach (string _line in lines)
            {
                string line = _line.Trim();
                if (line != "" && !line.StartsWith("#") && File.Exists(line))
                {
                    sargams.Add(line);
                }
            }

            return sargams;
        }
    }
}
