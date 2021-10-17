using dtos;

namespace libraries
{
    public class SemiTone : Tonality
    {
        public SemiTone()
        {
            this.height = 90;
            this.width = 40;

            this.bgcolor = "#999999";
            this.forecolor = "#FFFFFF";
        }
    }

    public class PureTone : Tonality
    {
        public PureTone()
        {
            this.height = 120;
            this.width = 60;

            this.bgcolor = "#FFFFFF";
            this.forecolor = "#000000";
        }
    }
}
