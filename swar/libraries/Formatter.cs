using configs;
using System.Collections.Generic;

namespace libraries
{
    // visually align the notations
    class Formatter
    {
        public string format_divisions(string line)
        {
            string outputs;
            List<string> output = new List<string>();

            string[] divisions = line.Split(new[] { SpecialKeys.PIPE_CHARACTER, });
            foreach (string division in divisions)
            {
                if (division != "")
                {
                    string notes = this.format_column(division);
                    output.Add(notes);
                }
            }

            outputs = string.Join(SpecialKeys.DIVISION_SEPARATOR_FORMATTER, output.ToArray());
            return outputs;
        }

        public string format_column(string column)
        {
            string outputs;
            List<string> output = new List<string>();

            string[] cells = column.Split(new[] { SpecialKeys.SPACE_CHARACTER, });
            foreach (string cell in cells)
            {
                if (cell != "")
                {
                    output.Add(this.format_cell(cell));
                }
            }
            outputs = string.Join(SpecialKeys.SPACE_CHARACTER.ToString(), output.ToArray());

            return outputs;
        }

        public string format_cell(string cell)
        {
            return string.Format("{0,-5}", cell);
        }
    }
}
