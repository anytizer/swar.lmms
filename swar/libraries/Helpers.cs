using System;
using System.IO;

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
            string[] beats = _beat.Split(new char[] { '/' });
            int denominator = int.Parse(beats[1]);

            return denominator;
        }

        public static int ParseTempo(string _tempo)
        {
            int tempo = int.Parse(_tempo);

            return tempo;
        }
    }
}
