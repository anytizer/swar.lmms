namespace dtos
{
    public class ComboItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string ExtraValue { get; set; }

        public ComboItem()
        {
            this.Text = "";
            this.Value = "";
            this.ExtraValue = "";
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
