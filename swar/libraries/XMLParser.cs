using dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace libraries
{
    public class XMLParser
    {
        private List<Note> notes;

        public XMLParser()
        {
            
        }

        public string generate(string scales)
        {
            this.notes = new List<Note>(); // to reset

            List<string> lines = this.getLines(scales);
            foreach (string line in lines)
            {
                List<string> divisions = this.getDivisions(line);
                foreach (string division in divisions)
                {
                    List<string> columns = this.getColumns(division); 
                    foreach (string column in columns)
                    {
                        this.process(column);
                    }
                }
            }

            string xpt = this.xpt(notes);
            return xpt;
        }

        private string xpt(List<Note> notes)
        {
            PianoKeys pk = new PianoKeys();

            int steps = 12;
            string xml = string.Format(@"<?xml version='1.0'?>
<!DOCTYPE lmms-project>
<lmms-project version='20' creatorversion='1.3.0-alpha.1.102+g89fc6c960' type='pattern' creator='LMMS'>
  <head/>
  <pattern steps='{0}' muted='0' name='' type='1' pos='0'>", steps);
            int pos = 0;
            foreach (Note note in notes)
            {
                int pianoKey = pk.getPianoKey(note.key);
                int lengthval = (int)Math.Ceiling(note.length * 48);
                xml += "\r\n    " + string.Format(@"<note pan='0' vol='100' key='{0}' len='{1}' pos='{2}' name='{3}: {4}' />", pianoKey, lengthval, pos, note.key, note.length);
                pos = pos + lengthval;
            }

            xml += @"
  </pattern>
</lmms-project>";

            return xml.Replace("'", "\"");
        }

        private List<string> getLines(string scales)
        {
            List<string> lines = new List<string>();
            foreach(string _line in scales.Split(new char[] { '\r', '\n' }))
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

            foreach (string division in rowline.Split('|'))
            {
                divisions.Add(division);
            }

            return divisions;
        }

        private List<string> getColumns(string division)
        {
            List<string> columns = new List<string>();
            foreach(string column in division.Split(new char[] { ' ' }))
            {
                columns.Add(column);
            }

            return columns;
        }

        private void process(string column)
        {
            if (column.Contains(","))
            {
                string[] newnotes = column.Split(","); // split multiple notes like C,B
                foreach (string newnote in newnotes)
                {
                    float newlength = 1 / newnotes.Count();
                    // notes.Add(new Note(newnote, newlength));
                    this.append(newnote, newlength);

                    // @todo Handle the case of - half note
                }
            }
            else if (column == "-")
            {
                if (notes.Count() > 0)
                {
                    notes.Last().length += 1;
                }
                else
                {
                    // error
                    // add blank note
                }
            }
            else if (column != "")
            {
                //notes.Add(new Note(column, 1));
                this.append(column, 1);
            }

            // @todo Handle more cases of C#* etc.
        }

        private void append(string cell, float length)
        {
            this.notes.Add(new Note(cell, length));
        }
    }
}