using System.Collections.Generic;

namespace libraries
{
    class Formatter
    {
        public string format_divisions(string line)
        {
            string outputs;
            List<string> output = new List<string>();

            string[] divisions = line.Split(new[] { '|', });
            foreach (string division in divisions)
            {
                if (division != "")
                {
                    string notes = this.format_column(division);
                    output.Add(notes);
                }
            }

            outputs = string.Join(" | ", output.ToArray());
            return outputs;
        }

        public string format_column(string column)
        {
            string outputs;
            List<string> output = new List<string>();

            string[] cells = column.Split(new[] { ' ', });
            foreach (string cell in cells)
            {
                if (cell != "")
                {
                    output.Add(this.format_cell(cell));
                }
            }
            outputs = string.Join(" ", output.ToArray());

            return outputs;
        }

        public string format_cell(string cell)
        {
            return string.Format("{0,-5}", cell);
        }
    }
}
