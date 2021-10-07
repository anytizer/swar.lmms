namespace dtos
{
    public class Signature
    {
        public int beat_nominator = 3;
        public int beat_denominator = 4;
        public int beat_quantization = 1 / 4;
        public int tempo = 123;

        // Beat: 2/4, 3/4, 4/4, 6/8
        // Tempo: 90, 123, 140, 280

        public Signature()
        {
            this.beat_nominator = 3;
            this.beat_denominator = 4;
            this.beat_quantization = 1 / 4;
            this.tempo = 123;
        }

        public Signature(int nominator, int deniminator, int tempo)
        {
            this.beat_nominator = nominator;
            this.beat_denominator = deniminator;
            this.beat_quantization = 1 / 4; // @todo Fix quantization
            this.tempo = tempo;
        }
    }
}
