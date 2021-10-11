﻿using configs;
using dtos;
using System.Collections.Generic;
using System.IO;

namespace libraries
{
    public class ApplicationSystem
    {
        public string convert(string sargam, Signature signature)
        {
            // string sargam = textBox1.Text;

            Replacer r = new Replacer();
            string scales = r.process(sargam);

            XMLHandler xml = new XMLHandler();
            List<string> xpts = xml.generate(scales, signature);

            Readyness rn = new Readyness();
            rn.DeleteXPTs();
            rn.write(scales, xpts);

            
            return scales;
        }
    }
}