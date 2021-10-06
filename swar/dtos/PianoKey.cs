namespace dtos
{
    public class PianoKey
    {
        public string name { get; set; }
        public int key { get; set; }

        public PianoKey(string _name, int _key)
        {
            this.name = _name;
            this.key = _key;
        }
    }
}
