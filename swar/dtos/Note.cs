namespace dtos
{
    public class Note
    {
        public string key { get; set; }
        public float length { get; set; }

        public Note(string _key, float _length)
        {
            this.key = _key;
            this.length = _length;
        }
    }
}
