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
            Signature s_2_4_140 = new Signature(Nominiators.TWO, Denominators.FOUR, Tempos.ONEFOURTY);
            Signature s_3_4_140 = new Signature(Nominiators.THREE, Denominators.FOUR, Tempos.ONEFOURTY);
            Signature s_2_4_280 = new Signature(Nominiators.TWO, Denominators.FOUR, Tempos.TWOEIGHTY);
            Signature s_3_4_280 = new Signature(Nominiators.THREE, Denominators.FOUR, Tempos.TWOEIGHTY); // popular teej melody
            Signature s_4_4_140 = new Signature(Nominiators.FOUR, Denominators.FOUR, Tempos.ONEFOURTY);
            Signature s_4_4_280 = new Signature(Nominiators.FOUR, Denominators.FOUR, Tempos.TWOEIGHTY);
            Signature s_6_8_280 = new Signature(Nominiators.SIX, Denominators.EIGHT, Tempos.TWOEIGHTY);

            List<string> sargams = Configurations.sargams();
            foreach(string sargam in sargams)
            {
                // @todo Select time signature from sargam file name itself
                this.read(sargam, s_3_4_280);
            }
        }
    }
}
