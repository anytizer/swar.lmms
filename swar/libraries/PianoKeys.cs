﻿using configs;
using dtos;
using System.Collections.Generic;
using System.Linq;

namespace libraries
{
    public class PianoKeys
    {
        List<PianoKey> keys;

        public PianoKeys()
        {
            this.keys = new List<PianoKey>(); // to reset
            Syllables solfege = new Syllables().translate(Scales.EnglishScale);

            this.fill(solfege);
        }

        private void fill(Syllables solfege)
        {
            this.register("C", 0, solfege.C);
            this.register("C#", 1, solfege.CSharp);
            this.register("D", 2, solfege.D);
            this.register("D#", 3, solfege.DSharp);
            this.register("E", 4, solfege.E);
            this.register("F", 5, solfege.F);
            this.register("F#", 6, solfege.FSharp);
            this.register("G", 7, solfege.G);
            this.register("G#", 8, solfege.GSharp);
            this.register("A", 9, solfege.A);
            this.register("A#", 10, solfege.ASharp);
            this.register("B", 11, solfege.B);
        }

        internal void register(string name, int key, string translation)
        {
            keys.Add(new PianoKey() { name = translation != "" ? translation : name, key = key });
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
            // on higher octave
            int octave = 4 + 1; // C4 is the standard key root
            if (name.Contains(SpecialKeys.HIGHER_OCTAVE_NOTATION))
            {
                octave += name.Count(s => s == SpecialKeys.HIGHER_OCTAVE_NOTATION_CHARACTER);
                name = name.Replace(SpecialKeys.HIGHER_OCTAVE_NOTATION, string.Empty);
            }

            // on lower octave
            if (name.Contains(SpecialKeys.LOWER_OCTAVE_NOTATION))
            {
                octave -= name.Count(s => s == SpecialKeys.LOWER_OCTAVE_NOTATION_CHARACTER);
                name = name.Replace(SpecialKeys.LOWER_OCTAVE_NOTATION, string.Empty);
            }

            int notenumber = this.search(name);
            int pianokey = 12 * octave + notenumber;

            return pianokey;
        }

        private bool specialKey(string key)
        {
            if (key == SpecialKeys.CONTINUATION)
                return true;
            else
                // @todo Handle silence
                // SpecialKeys.SILENCE
                return false;
        }

         // @todo Trims the notations
        public bool isValidKey(string key)
        {
            bool found = false;
    
            foreach(PianoKey pk in this.keys)
            {
                if(key == pk.name)
                {
                    found = true;
                }
            }

            if (this.specialKey(key))
                found = true;

            // slience
            // continuation

            return found;
        }
    }
}
