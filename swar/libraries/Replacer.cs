using configs;
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

            // oddities
            lr.Add(new Replacement() { find = "º", replace = SpecialKeys.HIGHER_OCTAVE_NOTATION });
            lr.Add(new Replacement() { find = "™", replace = SpecialKeys.HASH });
            // lr.Add(new Replacement() { find = "‘", replace = SpecialKeys.LOWER_OCTAVE_NOTATION }); // appears in front

            // common symbols
            lr.Add(new Replacement() { find = "°", replace = SpecialKeys.HIGHER_OCTAVE_NOTATION });
            lr.Add(new Replacement() { find = "*", replace = SpecialKeys.HIGHER_OCTAVE_NOTATION }); // not necessary | same destination
            lr.Add(new Replacement() { find = "`", replace = SpecialKeys.HASH }); // sharp/flat
            lr.Add(new Replacement() { find = "'", replace = SpecialKeys.HASH }); // sharp/flat
            lr.Add(new Replacement() { find = "’", replace = SpecialKeys.HASH }); // sharp/flat
            lr.Add(new Replacement() { find = "_", replace = SpecialKeys.CONTINUATION });
            lr.Add(new Replacement() { find = "~", replace = SpecialKeys.CONTINUATION });
            lr.Add(new Replacement() { find = "/", replace = SpecialKeys.PIPE });

            // to sargam - single letter
            lr.Add(new Replacement() { find = "h", replace = "" }); // Dha => h part
            lr.Add(new Replacement() { find = "a", replace = "" });
            lr.Add(new Replacement() { find = "e", replace = "" });
            lr.Add(new Replacement() { find = "i", replace = "" });

            // to sargam standards - multi letters
            lr.Add(new Replacement() { find = "s", replace = "sa" });
            lr.Add(new Replacement() { find = "r", replace = "re" });
            lr.Add(new Replacement() { find = "g", replace = "ga" });
            lr.Add(new Replacement() { find = "m", replace = "ma" });
            lr.Add(new Replacement() { find = "p", replace = "pa" });
            lr.Add(new Replacement() { find = "d", replace = "dh" });
            lr.Add(new Replacement() { find = "dh", replace = "dha" });
            lr.Add(new Replacement() { find = "n", replace = "ni" });

            // to english scales
            lr.Add(new Replacement() { find = "sa", replace = "C" });
            lr.Add(new Replacement() { find = "re", replace = "D" });
            lr.Add(new Replacement() { find = "ga", replace = "E" });
            lr.Add(new Replacement() { find = "ma", replace = "F" });
            lr.Add(new Replacement() { find = "pa", replace = "G" });
            lr.Add(new Replacement() { find = "dha", replace = "A" });
            lr.Add(new Replacement() { find = "ni", replace = "B" });
        }

        public string translate(string note, string to)
        {
            string note_translated = note;
            return note_translated;
            // eg. C => C
            // eg. C => SA
            // eg. C => सा
            // eg. C => DO
        }

        private string replace(string sargam)
        {
            // @todo Must be typed in lower case!
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
            scales = scales.Replace("(", "");
            scales = scales.Replace(")", "");
            scales = scales.Replace("{", "");
            scales = scales.Replace("}", "");


            string[] lines = scales.Split(new[] { '\r', '\n' });
            List<string> output = new List<string>();

            int line_number = 0;
            Formatter f = new Formatter();

            for (int i = 0; i < lines.Length; ++i)
            {
                string line = lines[i].Trim();
                if (line != "")
                {
                    if (!line.StartsWith(SpecialKeys.HASH))
                    {
                        ++line_number;

                        line = this.replace(line.ToLower());
                        output.Add(string.Format("{0,2}: {1}", line_number, f.format_divisions(line)));
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
