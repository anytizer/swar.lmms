namespace dtos
{
    public class Signature
    {
        public int beat_nominator { get; set; } = 0;
        public int beat_denominator { get; set; } = 0;
        public float quantization { get; set; } = 0.00f;
        public int tempo { get; set; } = 0;

        public Signature(int nominator, int deniminator, int tempo)
        {
            this.beat_nominator = nominator;
            this.beat_denominator = deniminator;
            this.quantization = 1.0f / 4; // @todo Fix quantization
            this.tempo = tempo;
        }
    }
}
