namespace dtos
{
    public class Tone
    {
        public string name { get; set; }
        public string frequency { get; set; }
        public string wavelength { get; set; }

        public Tonality tonality { get; set; }
    }
}
