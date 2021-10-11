using configs;
using dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace libraries
{
    public class XMLHandler
    {
        public XMLHandler()
        {
            // line number
            // division number
            // column number
            // position number within a cell: eg.: C,D
            // actual notation
            // play length factor
        }

        public List<string> generate(string scales, Signature signature)
        {
            List<string> xpts = new List<string>();

            List<string> blocks = this.getBlocks(scales); // #//
            ColorsRotator c = new ColorsRotator();
            int sequence = 0;
            foreach (string block in blocks)
            {
                List<Cell> rawnotes = this.getCells(block);

                /**
                 * Lengths re-adjusted
                 * Subset of rawnotes, except length
                 */
                List<Cell> notes = this.process(rawnotes);

                string xpt = this.xpt(notes, signature, ++sequence, c.getNextColor());
                xpts.Add(xpt);
            }

            return xpts;
        }

        private List<string> getBlocks(string scales)
        {
            List<string> blocks = new List<string>();
            string[] raw_blocks = scales.Split("#//");
            foreach (string _block in raw_blocks)
            {
                string block = _block.Trim();
                if (block != "")
                {
                    blocks.Add(block);
                }
            }
            
            return blocks;
        }

        public List<Cell> getCells(string scales)
        {
            PianoKeys pk = new PianoKeys();
            List<Cell> notes = new List<Cell>();

            int line_number = -1;

            List<string> lines = this.getLines(scales);
            foreach (string line in lines)
            {
                ++line_number;

                int division_number = -1;

                List<string> divisions = this.getDivisions(line);
                foreach (string _division in divisions)
                {
                    ++division_number;
                    int column_number = 0;

                    List<string> columns = this.getColumns(_division);
                    foreach (string column in columns)
                    {
                        ++column_number;

                        int position_number = -1;

                        if (column.Contains(","))
                        {
                            int elements = column.Count(s => s == ',') + 1; 
                            float semilength = 1.0f / elements; // @todo Avoid division by zero
                            List<string> notations = this.getNotations(column);
                            foreach (string seminote in notations)
                            {
                                ++position_number;

                                notes.Add(new Cell
                                {
                                    line = line_number,
                                    division = division_number,
                                    column = column_number,
                                    position = position_number,
                                    notation = seminote,
                                    length = semilength,
                                });
                            }
                        }
                        else if (column!="") // (pk.isValidKey(column))
                        //else if (pk.isValidKey(column))
                        {
                            notes.Add(new Cell
                            {
                                line = line_number,
                                division = division_number,
                                column = column_number,
                                position = position_number,
                                notation = column,
                                length = 1,
                            });
                        }
                        else
                        {
                            // error!
                        }
                    }
                }
            }

            return notes;
        }

        private string xpt(List<Cell> notes, Signature signature, int sequence, Color color)
        {
            PianoKeys pk = new PianoKeys();

            int steps = signature.beat_nominator * signature.beat_denominator;

            string xml = string.Format(@"<?xml version='1.0'?>
<!DOCTYPE lmms-project>
<lmms-project version='20' creatorversion='{0}' type='pattern' creator='{1}'>
  <head/>
  <pattern steps='{2}' muted='0' name='{3}' color='{4}' type='1' pos='0'>", Configurations.version, Configurations.name, steps, sequence, color.code);
            int pos = 0;
            foreach (Cell note in notes)
            {
                int pianoKey = pk.getPianoKey(note.notation);
                int lengthval = (int)Math.Ceiling(note.length * 48);
                xml += "\r\n    " + string.Format(@"<note pan='0' vol='100' key='{0}' len='{1}' pos='{2}' name='{3}: {4}' />", pianoKey, lengthval, pos, note.notation, note.length);
                pos = pos + lengthval;
            }

            xml += @"
  </pattern>
</lmms-project>";

            xml = xml.Replace("'", "\"");

            return xml;
        }

        private List<string> getLines(string scales)
        {
            List<string> lines = new List<string>();
            foreach (string _line in scales.Split(new char[] { '\r', '\n' }))
            {
                string line = _line.Trim();
                if (line == "" || line.StartsWith("#") || line.StartsWith("x"))
                    continue;

                lines.Add(line);
            }

            return lines;
        }

        private List<string> getDivisions(string line)
        {
            string rowline;
            List<string> divisions = new List<string>();
            if (line.Contains(":"))
            {
                string[] raws = line.Split(":");
                rowline = raws[1];
            }
            else
            {
                rowline = line;
            }

            foreach (string _division in rowline.Split('|'))
            {
                string division = _division.Trim();
                if(division!="")
                {
                    divisions.Add(division);
                }
            }

            return divisions;
        }

        private List<string> getColumns(string division)
        {
            List<string> columns = new List<string>();
            foreach (string _column in division.Split(new char[] { ' ' }))
            {
                string column = _column.Trim();
                if (column != "")
                {
                    columns.Add(column);
                }
            }

            return columns;
        }

        private List<string> getNotations(string column)
        {
            List<string> notations = new List<string>();
            foreach (string _notation in column.Split(",")) // split multiple notes like C,B
            {
                string notation = _notation.Trim();
                if(notation!="")
                {
                    notations.Add(notation);
                }
            }

            return notations;
        }

        private List<Cell> process(List<Cell> notes)
        {
            List<Cell> processed = new List<Cell>();
            foreach (Cell cell in notes)
            {
                if (cell.notation == "-")
                {
                    if (processed.Count() > 0)
                    {
                        processed.Last().length += cell.length;
                    }
                    else
                    {
                        // cannot start with a -
                    }
                }
                else if (cell.notation == "x")
                {
                    // add a blank note
                    // increase the position
                    // can! start with x
                }
                else
                {
                    processed.Add(cell);
                }
            }

            return processed;
        }
    }
}