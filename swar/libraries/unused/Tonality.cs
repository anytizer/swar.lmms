using dtos;

namespace libraries
{
    public class SemiTone : Tonality
    {
        public SemiTone()
        {
            this.height = 90;
            this.width = 40;
        }
    }

    public class PureTone : Tonality
    {
        public PureTone()
        {
            this.height = 120;
            this.width = 60;
        }
    }
}
