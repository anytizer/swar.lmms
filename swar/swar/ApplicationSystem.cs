using dtos;
using libraries;
using System;
using System.Windows.Forms;

namespace swar
{
    class ApplicationSystem
    {
        internal void reboot(ComboBox comboBox1, ComboBox comboBox2)
        {
            comboBox1.Items.Clear();
            Converter c = new Converter();
            foreach (ComboItem ci in c.getConverters())
            {
                comboBox1.Items.Add(new ComboItem()
                {
                    Text = ci.Text,
                    Value = ci.Value,
                    ExtraValue = "",
                });
            }

            LyricsReader lr = new LyricsReader();
            lr.load();

            comboBox2.Items.Clear();
            foreach (string filename in lr.getFiles())
            {
                comboBox2.Items.Add(new ComboItem()
                {
                    Text = Helpers.SongTitle(filename),
                    Value = lr.lyrics(filename),
                    ExtraValue = filename,
                });
            }
        }
    }
}
