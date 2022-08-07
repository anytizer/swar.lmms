using configs;
using dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace libraries
{
    public class XMLHandler
    {
        private const int width = 48; // 4 x 16 pixels = 48

        public XMLHandler()
        {
            // line number
            // division number
            // column number
            // position number within a cell: eg.: C,D
            // actual notation
            // play length factor
        }

        public List<string> generate(string scales, Signature signature, bool split = true)
        {
            List<string> xpts = new List<string>();

            List<string> blocks = this.getBlocks(scales, split); // Commented with: #//
            ColorsRotator cr = new ColorsRotator();
            int sequence = 0;
            foreach (string block in blocks)
            {
                List<Cell> rawnotes = this.getCells(block);

                /**
                 * Lengths re-adjusted
                 * Subset of rawnotes, except length
                 */
                List<Cell> notes = this.process(rawnotes);

                string xpt = this.xpt(notes, signature, ++sequence, cr.getNextColor());
                xpts.Add(xpt);
            }

            return xpts;
        }

        private List<string> getBlocks(string scales, bool split = true)
        {
            List<string> blocks = new List<string>() { };

            string[] raw_blocks = { };
            if (split)
            {
                raw_blocks = scales.Split(SpecialKeys.BLOCK_SEPARATOR);
                foreach (string _block in raw_blocks)
                {
                    string block = _block.Trim();
                    if (block != "")
                    {
                        blocks.Add(block);
                    }
                }
            }
            else
            {
                blocks.Add(scales);
            }


            return blocks;
        }

        public List<Cell> getCells(string scales)
        {
            PianoKeys pk = new PianoKeys();
            List<Cell> cells = new List<Cell>();

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

                        if (column.Contains(SpecialKeys.COMMA))
                        {
                            int elements = column.Count(s => s == SpecialKeys.COMMA_CHARACTER) + 1;
                            float semilength = 1.0f / elements; // @todo Avoid division by zero
                            List<string> notations = this.getNotations(column);
                            foreach (string seminote in notations)
                            {
                                ++position_number;

                                cells.Add(new Cell
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
                        else if (column != "" && column != SpecialKeys.PIPE) // working
                        //else // if (pk.isValidKey(column))
                        //else if (pk.isValidKey(column))
                        {
                            cells.Add(new Cell
                            {
                                line = line_number,
                                division = division_number,
                                column = column_number,
                                position = position_number,
                                notation = column,
                                length = 1.0f,
                            });
                        }
                    }
                }
            }

            return cells;
        }

        private string xpt(List<Cell> notes, Signature signature, int sequence, Coloring color)
        {
            PianoKeys pk = new PianoKeys();

            int steps = signature.beat_nominator * signature.beat_denominator;

            string xml = string.Format(@"<?xml version='1.0'?>
<!DOCTYPE lmms-project>
<lmms-project version='20' creatorversion='{0}' type='midiclip' creator='{1}'>
    <head/>
    <midiclip steps='{2}' muted='0' name='{3}' color='{4}' type='1' pos='0'>", Configurations.version, Configurations.name, steps, sequence, color.code);

            int pos = 0;
            List<Cell> cells = new List<Cell>() { };

            foreach (Cell cell in notes)
            {
                int unit_length = (int)Math.Ceiling(cell.length * XMLHandler.width);

                if (cell.notation == SpecialKeys.CONTINUATION)
                {
                    if (cells.Count > 0)
                    {
                        cells.Last().length += unit_length;

                        continue;
                    }
                    else
                    {
                        // cannot start with a continuation in the first
                    }

                    // @todo if the position is in last..., include it
                }
                else if (cell.notation == SpecialKeys.SILENCE)
                {
                    pos += unit_length;
                    continue;
                }

                Cell new_cell = cell;
                new_cell.position = pos;
                new_cell.length = unit_length;

                cells.Add(new_cell);

                pos += unit_length; // prepare for next loop
            }
















            //foreach (Cell cell in notes)
            foreach (Cell cell in cells)
            {
                int pianoKey = pk.getPianoKey(cell.notation);
                xml += "\r\n    " + string.Format(@"<note pan='0' vol='100' key='{0}' len='{1}' pos='{2}' name='{3}: {4}' />", pianoKey, cell.length, cell.position, cell.notation, cell.length);
            }

            xml += @"
    </midiclip>
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
                if (line == "" || line.StartsWith(SpecialKeys.HASH) || line.StartsWith(SpecialKeys.SILENCE))
                    continue;

                lines.Add(line);
            }

            return lines;
        }

        private List<string> getDivisions(string line)
        {
            string rowline;
            List<string> divisions = new List<string>();
            if (line.Contains(SpecialKeys.COLON))
            {
                string[] raws = line.Split(SpecialKeys.COLON);
                rowline = raws[1];
            }
            else
            {
                rowline = line;
            }

            foreach (string _division in rowline.Split(SpecialKeys.PIPE_CHARACTER))
            {
                string division = _division.Trim();
                if (division != "")
                {
                    divisions.Add(division);
                }
            }

            return divisions;
        }

        private List<string> getColumns(string division)
        {
            List<string> columns = new List<string>();
            foreach (string _column in division.Split(new char[] { SpecialKeys.SPACE_CHARACTER }))
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
            foreach (string _notation in column.Split(SpecialKeys.COMMA)) // split multiple notes like C,B
            {
                string notation = _notation.Trim();
                if (notation != "")
                {
                    notations.Add(notation);
                }
            }

            return notations;
        }

        private List<Cell> process(List<Cell> rawnotes)
        {
            // @todo: 'x' can appear in the begining as well

            List<Cell> processed = new List<Cell>();


            foreach (Cell cell in rawnotes)
            {

                if (cell.notation == SpecialKeys.CONTINUATION)
                {
                    if (processed.Count() > 0)
                    {
                        processed.Last().length += cell.length;
                    }
                    else
                    {
                        //processed.Add(cell);
                    }

                }
                else if (cell.notation == SpecialKeys.SILENCE)
                {
                    //processed.Last().length += cell.length;
                    processed.Add(cell);
                }
                else
                {
                    // cannot start with a -
                    // @todo However, can start with x
                    processed.Add(cell);
                }
            }

            return processed;
        }
    }
}