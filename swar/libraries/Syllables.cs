using configs;

namespace libraries
{
    internal class Syllables
    {
        public string C = "C";
        public string CSharp = "C#";
        public string D = "D";
        public string DSharp = "D#";
        public string E = "E";
        public string F = "F";
        public string FSharp = "F#";
        public string G = "G";
        public string GSharp = "G#";
        public string A = "A";
        public string ASharp = "A#";
        public string B = "B";

        public Syllables()
        {
            //this = this._getSargam();
        }

        internal Syllables translate(string name)
        {
            Syllables target;
            switch (name)
            {
                case Scales.Sargam:
                    target = this._getSargam();
                    break;
                case Scales.RomanShort:
                    target = this._getRomanShort();
                    break;
                case Scales.EnglishScale:
                    target = this._getEnglishScale();
                    break;
                case Scales.NorthIndianClassicalUnicode:
                default:
                    target = this._getNorthIndianClassicalUnicode();
                    break;
            }

            return target;
        }

        private Syllables _getSargam()
        {
            Syllables target = new Syllables
            {
                C = "Sa",
                CSharp = "Sa'",
                D = "Re",
                DSharp = "Re'",
                E = "Ga",
                F = "Ma",
                FSharp = "Ma'",
                G = "Pa",
                GSharp = "Pa'",
                A = "Dha",
                ASharp = "Dha'",
                B = "Ni"
            };

            return target;
        }

        private Syllables _getRomanShort()
        {
            Syllables target = new Syllables
            {
                C = "S",
                CSharp = "S'",
                D = "R",
                DSharp = "R'",
                E = "G",
                F = "M",
                FSharp = "M'",
                G = "P",
                GSharp = "P'",
                A = "D",
                ASharp = "D'",
                B = "N"
            };

            return target;
        }

        private Syllables _getEnglishScale()
        {
            Syllables target = new Syllables
            {
                C = "C",
                CSharp = "C#",
                D = "D",
                DSharp = "D#",
                E = "E",
                F = "F",
                FSharp = "F#",
                G = "G",
                GSharp = "G#",
                A = "A",
                ASharp = "A#",
                B = "B"
            };

            return target;
        }

        private Syllables _getNorthIndianClassicalUnicode()
        {
            Syllables target = new Syllables
            {
                C = "सा",
                CSharp = "सा'",
                D = "रे",
                DSharp = "रे'",
                E = "ग",
                F = "म",
                FSharp = "म'",
                G = "प",
                GSharp = "प'",
                A = "ध",
                ASharp = "ध'",
                B = "नि"
            };

            return target;
        }
    }
}