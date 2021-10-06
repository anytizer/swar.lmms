using dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swar
{
    public class NotesLoader
    {
        public NotesLoader()
        {

        }

        public List<Tone> LoadNotes()
        {
            List<Tone> tones = new List<Tone>();
            // https://pages.mtu.edu/~suits/notefreqs.html
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "261.63", wavelength = "131.87", name = "C" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "277.18", wavelength = "124.47", name = "C#" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "293.66", wavelength = "117.48", name = "D" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "311.13", wavelength = "110.89", name = "D#" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "329.63", wavelength = "104.66", name = "E" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "349.23", wavelength = "98.79", name = "F" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "369.99", wavelength = "93.24", name = "F#" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "392.00", wavelength = "88.01", name = "G" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "415.30", wavelength = "83.07", name = "G#" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "440.00", wavelength = "78.41", name = "A" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "466.16", wavelength = "74.01", name = "A#" });
            tones.Add(new Tone() { bgcolor = "#999999", color = "#000000", frequency = "493.88", wavelength = "69.85", name = "B" });

            return tones;
        }
    }
}