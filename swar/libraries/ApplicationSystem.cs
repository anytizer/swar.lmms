using dtos;
using System.Collections.Generic;

namespace libraries
{
    public class ApplicationSystem
    {
        public string convert(string sargam, Signature signature)
        {
            Replacer r = new Replacer();
            string scales = r.process(sargam);

            XMLHandler xml = new XMLHandler();
            List<string> xpts = xml.generate(scales, signature);

            Readyness rn = new Readyness();
            rn.DeleteXPTs();
            rn.write(scales, xpts);
            
            return scales;
        }

        public string no_comments_on_screen(string with_comments="")
        {
            string no_comments = "";
            List<string> output = new List<string>() { };
            string[] no_comments_lined = with_comments.Split(new[] { '\r', '\n' });
            foreach(string line in no_comments_lined)
            {
                if (!line.StartsWith(configs.SpecialKeys.HASH) && line!="")
                {
                    output.Add(line);
                }
            }

            no_comments = string.Join("\r\n", output);
            return no_comments;
        }
    }
}
