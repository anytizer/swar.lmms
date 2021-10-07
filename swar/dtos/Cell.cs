namespace dtos
{
    public class Cell
    {
        public string key { get; set; }
        public float length { get; set; }

        public Cell(string _key, float _length)
        {
            this.key = _key;
            this.length = _length;
        }
    }
}
