using configs;
using dtos;
using System.Collections.Generic;

namespace libraries
{
    public class ApplicationSystem
    {
        public string convert(string sargam, Signature signature, string to, bool split = true)
        {
            Replacer r = new Replacer();
            string scales = r.process(sargam);

            scales = r.translate(scales, to);

            XMLHandler xml = new XMLHandler();
            List<string> xpts = xml.generate(scales, signature, split);

            Readyness rn = new Readyness();
            rn.DeleteXPTs();
            rn.write(scales, xpts);

            return scales;
        }

        public string no_comments_on_screen(string with_comments = "")
        {
            List<string> output = new List<string>() { };
            string[] no_comments_lined = with_comments.Split(new[] { '\r', '\n' });
            foreach (string line in no_comments_lined)
            {
                if (!line.StartsWith(configs.SpecialKeys.HASH) && line != "")
                {
                    output.Add(line);
                }
            }

            string no_comments = string.Join("\r\n", output);
            return no_comments;
        }
    }
}
