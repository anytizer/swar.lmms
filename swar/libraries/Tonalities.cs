using dtos;

namespace libraries
{
    public class SemiTone : Tonality
    {
        public SemiTone()
        {
            this.height = 90;
            this.width = 40;

            this.bgcolor = new Coloring { code = "#999999", name = "gray" };
            this.forecolor = new Coloring { code = "#FFFFFF", name = "white" };
        }
    }

    public class PureTone : Tonality
    {
        public PureTone()
        {
            this.height = 120;
            this.width = 60;

            this.bgcolor = new Coloring { code = "#FFFFFF", name = "white" };
            this.forecolor = new Coloring { code = "#000000", name = "black" };
        }
    }
}
