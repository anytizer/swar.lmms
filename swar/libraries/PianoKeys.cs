using dtos;
using System.Collections.Generic;
using System.Linq;

namespace libraries
{
    class PianoKeys
    {
        List<PianoKey> keys;

        public PianoKeys()
        {
            this.keys = new List<PianoKey>(); // to reset
            this.register("C", 0);
            this.register("C#", 1);
            this.register("D", 2);
            this.register("D#", 3);
            this.register("E", 4);
            this.register("F", 5);
            this.register("F#", 6);
            this.register("G", 7);
            this.register("G#", 8);
            this.register("A", 9);
            this.register("A#", 10);
            this.register("B", 11);
        }

        internal void register(string name, int key)
        {
            keys.Add(new PianoKey(name, key));
        }

        internal int search(string name)
        {
            int key = -1;
            foreach (PianoKey pk in this.keys)
            {
                if (pk.name == name)
                {
                    key = pk.key;
                }
            }

            return key;
        }

        public int getPianoKey(string name)
        {
            int octave = 4 + 1;
            if (name.Contains("*"))
            {
                octave += name.Count(s => s == '*');
                name = name.Replace("*", "");
            }

            if (name.Contains("."))
            {
                octave -= name.Count(s => s == '.');
                name = name.Replace(".", "");
            }

            int notenumber = this.search(name);
            int pianokey = 12 * octave + notenumber;

            return pianokey;
        }
    }
}
