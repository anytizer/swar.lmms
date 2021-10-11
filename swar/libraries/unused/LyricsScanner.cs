using dtos;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace libraries
{
    // to build a list of databases
    public class LyricsScanner
    {
        public List<Lyrics> scan(string dir)
        {
            List<Lyrics> ls = new List<Lyrics>();

            string[] songs = Directory.GetDirectories(dir);
            foreach (string song in songs)
            {
                Lyrics l = this.ScanNotes(song);
                ls.Add(l);
            }

            return ls;
        }

        private Lyrics ScanNotes(string song)
        {
            Lyrics l = new Lyrics();
            
            l.filename = song;
            l.lyrics = File.ReadAllText(song, Encoding.UTF8);
            
            return l;
        }
    }
}
