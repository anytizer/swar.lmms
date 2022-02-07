using configs;
using dtos;
using System.Collections.Generic;

namespace libraries
{
    public class NotesLoader
    {
        public List<Tone> tones;

        // @todo Pass translation parameter as a DTO/Enum
        public List<Tone> LoadNotes(string translation)
        {
            // Syllables solfege = new Syllables().translate(Scales.NorthIndianClassicalUnicode);
            // Syllables solfege = new Syllables().translate(Scales.Sargam);
            Syllables solfege = new Syllables().translate(translation);

            SemiTone semi = new SemiTone();
            PureTone pure = new PureTone();

            // Reference: https://pages.mtu.edu/~suits/notefreqs.html
            // Bhatkhande Update: The seasons may change the density of air and hence, diffrent quality is required.
            this.tones = new List<Tone>();
            tones.Add(new Tone() { frequency = "261.63", wavelength = "131.87", name = solfege.C, tonality = pure });
            tones.Add(new Tone() { frequency = "277.18", wavelength = "124.47", name = solfege.CSharp, tonality = semi });
            tones.Add(new Tone() { frequency = "293.66", wavelength = "117.48", name = solfege.D, tonality = pure });
            tones.Add(new Tone() { frequency = "311.13", wavelength = "110.89", name = solfege.DSharp, tonality = semi });
            tones.Add(new Tone() { frequency = "329.63", wavelength = "104.66", name = solfege.E, tonality = pure });
            tones.Add(new Tone() { frequency = "349.23", wavelength = "98.79", name = solfege.F, tonality = pure });
            tones.Add(new Tone() { frequency = "369.99", wavelength = "93.24", name = solfege.FSharp, tonality = semi });
            tones.Add(new Tone() { frequency = "392.00", wavelength = "88.01", name = solfege.G, tonality = pure });
            tones.Add(new Tone() { frequency = "415.30", wavelength = "83.07", name = solfege.GSharp, tonality = semi });
            tones.Add(new Tone() { frequency = "440.00", wavelength = "78.41", name = solfege.A, tonality = pure });
            tones.Add(new Tone() { frequency = "466.16", wavelength = "74.01", name = solfege.ASharp, tonality = semi });
            tones.Add(new Tone() { frequency = "493.88", wavelength = "69.85", name = solfege.B, tonality = pure });

            return tones;
        }
    }
}
