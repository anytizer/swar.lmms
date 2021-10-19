using configs;
using dtos;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace libraries
{
    public class LyricsReader
    {
        List<Lyrics> readings = new List<Lyrics>();

        public string read(string filename, Signature signature)
        {
            string lyrics = "";
            if (File.Exists(filename))
            {
                lyrics = this.lyrics(filename);
            
                readings.Add(new Lyrics() {
                    filename = filename,
                    lyrics = lyrics,
                    signature = signature,
                });
            }

            return lyrics;
        }

        public List<string> getFiles()
        {
            List<string> files = new List<string>();
            foreach(Lyrics l in this.readings)
            {
                files.Add(l.filename);
            }

            return files;
        }

        public string lyrics(string filename)
        {
            string lyrics = File.ReadAllText(filename, Encoding.UTF8);
            return lyrics;
        }

        public void load()
        {
            List<string> sargams = Configurations.sargams();
            foreach(string sargam in sargams)
            {
                // Select time signature from sargam file name itself
                Signature signature = Helpers.Signature(sargam);
                this.read(sargam, signature); // default: s_3_4_280
            }
        }
    }
}
