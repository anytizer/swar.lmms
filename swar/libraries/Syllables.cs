using configs;
using dtos;
using System;

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

        public static object setup { get; internal set; }

        internal Syllables translate(string name)
        {
            Syllables target = new Syllables();
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
            Syllables target = new Syllables();
            target.C = "Sa";
            target.CSharp = "Sa'";
            target.D = "Re";
            target.DSharp = "Re'";
            target.E = "Ga";
            target.F = "Ma";
            target.FSharp = "Ma'";
            target.G = "Pa";
            target.GSharp = "Pa'";
            target.A = "Dha";
            target.ASharp = "Dha'";
            target.B = "Ni";

            return target;
        }

        private Syllables _getRomanShort()
        {
            Syllables target = new Syllables();
            target.C = "S";
            target.CSharp = "S'";
            target.D = "R";
            target.DSharp = "R'";
            target.E = "G";
            target.F = "M";
            target.FSharp = "M'";
            target.G = "P";
            target.GSharp = "P'";
            target.A = "D";
            target.ASharp = "D'";
            target.B = "N";

            return target;
        }

        private Syllables _getEnglishScale()
        {
            Syllables target = new Syllables();
            target.C = "C";
            target.CSharp = "C#";
            target.D = "D";
            target.DSharp = "D#";
            target.E = "E";
            target.F = "F";
            target.FSharp = "F#";
            target.G = "G";
            target.GSharp = "G#";
            target.A = "A";
            target.ASharp = "A#";
            target.B = "B";

            return target;
        }

        private Syllables _getNorthIndianClassicalUnicode()
        {
            Syllables target = new Syllables();
            target.C = "सा";
            target.CSharp = "सा'";
            target.D = "रे";
            target.DSharp = "रे'";
            target.E = "ग";
            target.F = "म";
            target.FSharp = "म'";
            target.G = "प";
            target.GSharp = "प'";
            target.A = "ध";
            target.ASharp = "ध'";
            target.B = "नि";

            return target;
        }
    }
}