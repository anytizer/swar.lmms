using libraries;
using System.Collections.Generic;

namespace dtos
{
    public class Replacer
    {
        List<Replacement> lr;

        public Replacer()
        {
            lr = new List<Replacement>();

            lr.Add(new Replacement() { find = "°", replace = "*" });
            lr.Add(new Replacement() { find = "º", replace = "*" });
            lr.Add(new Replacement() { find = "™", replace = "*" });
            lr.Add(new Replacement() { find = "`", replace = "#" }); // sharp/flat
            lr.Add(new Replacement() { find = "'", replace = "#" }); // sharp/flat
            lr.Add(new Replacement() { find = "_", replace = "-" });
            lr.Add(new Replacement() { find = "~", replace = "-" });
            lr.Add(new Replacement() { find = "/", replace = "|" });

            lr.Add(new Replacement() { find = "a", replace = "" });
            lr.Add(new Replacement() { find = "e", replace = "" });
            lr.Add(new Replacement() { find = "i", replace = "" });
            lr.Add(new Replacement() { find = "h", replace = "" }); // Dha

            lr.Add(new Replacement() { find = "s", replace = "sa" });
            lr.Add(new Replacement() { find = "r", replace = "re" });
            lr.Add(new Replacement() { find = "g", replace = "ga" });
            lr.Add(new Replacement() { find = "m", replace = "ma" });
            lr.Add(new Replacement() { find = "p", replace = "pa" });
            lr.Add(new Replacement() { find = "d", replace = "dh" });
            lr.Add(new Replacement() { find = "dh", replace = "dha" });
            lr.Add(new Replacement() { find = "n", replace = "ni" });

            lr.Add(new Replacement() { find = "sa", replace = "C" });
            lr.Add(new Replacement() { find = "re", replace = "D" });
            lr.Add(new Replacement() { find = "ga", replace = "E" });
            lr.Add(new Replacement() { find = "ma", replace = "F" });
            lr.Add(new Replacement() { find = "pa", replace = "G" });
            lr.Add(new Replacement() { find = "dha", replace = "A" });
            lr.Add(new Replacement() { find = "ni", replace = "B" });
        }

        public string replace(string sargam)
        {
            string scales = sargam; // .ToLower();
            foreach (Replacement r in lr)
            {
                scales = scales.Replace(r.find, r.replace);
            }

            return scales;
        }

        public string process(string sargam)
        {
            string scales = sargam;
            string[] lines = scales.Split(new[] { '\r', '\n' });
            List<string> output = new List<string>();

            Formatter f = new Formatter();
            int linenumber = 0;

            for (int i = 0; i < lines.Length; ++i)
            {
                string line = lines[i].Trim();
                if (line != "")
                {
                    if (!line.StartsWith("#"))
                    {
                        ++linenumber;
                        line = line.ToLower();
                        line = this.replace(line.ToLower());
                        output.Add(string.Format("{0,2}: {1}", linenumber, f.format_divisions(line)));
                    }
                    else
                    {
                        output.Add(line);
                    }
                }
            }

            string outputs = string.Join("\r\n", output.ToArray());
            return outputs;
        }
    }
}
