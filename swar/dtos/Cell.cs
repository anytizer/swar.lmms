namespace dtos
{
    public class Cell
    {
        /**
         * On which line number of the notation file
         */
        public int line { get; set; } = 0;

        /**
         * Vertical division number seprated by |
         */
        public int division { get; set; } = 0;

        /**
         * Column number within a division seprated by [space]
         */
        public int column { get; set; } = 0;

        /**
         * Position within column when separated by [comma]
         */
        public int position { get; set; } = 0;

        /**
         * Notation
         */
        public string notation { get; set; } = "";

        /**
         * Beat length controller
         * eg. 1.00, 0.50, 0.33, 0.25
         */
        public float length { get; set; } = 0.00f;

        /**
         * Dump when debugging
         */
        public override string ToString()
        {
            return string.Format("{0}: {1}", this.notation, this.length);
        }
    }
}