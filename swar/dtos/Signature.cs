namespace dtos
{
    public class Signature
    {
        public int beat_nominator { get; set; }
        public int beat_denominator { get; set; }
        public float quantization { get; set; }
        public int tempo { get; set; }

        public Signature(int nominator, int deniminator, int tempo)
        {
            this.beat_nominator = nominator;
            this.beat_denominator = deniminator;
            this.quantization = 1.0f / 4; // @todo Fix quantization
            this.tempo = tempo;
        }
    }
}
