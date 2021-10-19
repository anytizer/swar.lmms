using configs;
using dtos;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace libraries
{
    public static class Helpers
    {
        // eg. D:\project-one\notations\notations-sargams.txt => project-one
        // eg. D:\project-one\notations-sargams.txt => project-one
        public static string SongTitle(string notations_file = "")
        {
            DirectoryInfo parent = Directory.GetParent(notations_file);
            string title = parent.Name;

            /**
             * If we had put all notations within a standard directory name.
             */
            if (title == "notations")
            {
                title = parent.Parent.Name;
            }

            return title.Replace("-", " ");
        }

        public static int ParseNominator(string _beat)
        {
            string[] beats = _beat.Split(new char[] { '/' });
            int nominator = int.Parse(beats[0]);
            
            return nominator;
        }

        public static int ParseDenominator(string _beat)
        {
            string[] beats = _beat.Split(new char[] { SpecialKeys.BEAT_SEPARATOR });
            int denominator = int.Parse(beats[1]);

            return denominator;
        }

        public static int ParseTempo(string _tempo)
        {
            int tempo = int.Parse(_tempo);

            return tempo;
        }

        public static Signature Signature(string filename)
        {
            // Popular Time Signatures
            Signature s_2_4_140 = new Signature(Nominiators.TWO, Denominators.FOUR, Tempos.ONEFOURTY);
            Signature s_3_4_140 = new Signature(Nominiators.THREE, Denominators.FOUR, Tempos.ONEFOURTY);
            Signature s_2_4_280 = new Signature(Nominiators.TWO, Denominators.FOUR, Tempos.TWOEIGHTY);
            Signature s_3_4_280 = new Signature(Nominiators.THREE, Denominators.FOUR, Tempos.TWOEIGHTY); // popular teej melody
            Signature s_4_4_140 = new Signature(Nominiators.FOUR, Denominators.FOUR, Tempos.ONEFOURTY);
            Signature s_4_4_280 = new Signature(Nominiators.FOUR, Denominators.FOUR, Tempos.TWOEIGHTY);
            Signature s_6_8_280 = new Signature(Nominiators.SIX, Denominators.EIGHT, Tempos.TWOEIGHTY);

            int nominator = Nominiators.FOUR;
            int denominator = Denominators.FOUR;
            int tempo = Tempos.ONEFOURTY;

            FileInfo fi = new FileInfo(filename);

            string pattern = @"^notations-sargams-(\d+)-(\d+)-(\d+)\.txt$";
            Regex re = new Regex(pattern);
            Match chunks = re.Match(fi.Name);
            if(chunks.Groups.Count == 4)
            {
                nominator = int.Parse(chunks.Groups[1].Value);
                denominator = int.Parse(chunks.Groups[2].Value);
                tempo = int.Parse(chunks.Groups[3].Value);
            }

            Signature ds = new Signature(nominator, denominator, tempo);

            return ds;
        }
    }
}
