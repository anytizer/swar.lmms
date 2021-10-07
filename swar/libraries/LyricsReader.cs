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
            // Popular Time Signatures
            Signature s1 = new Signature(2, 4, 140);
            Signature s2 = new Signature(3, 4, 140);
            Signature s3 = new Signature(2, 4, 280);
            Signature s4 = new Signature(3, 4, 280); // popular teej melody
            Signature s5 = new Signature(6, 8, 280);

            List<string> sargams = Configurations.sargams();
            foreach(string sargam in sargams)
            {
                this.read(sargam, s4);
            }           
        }
    }
}
