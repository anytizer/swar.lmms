using configs;
using dtos;
using libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace swar
{
    public partial class swar : Form
    {
        ApplicationSystem s;
        Signature signature;

        public swar()
        {
            InitializeComponent();
            this.s = new ApplicationSystem();
            this.signature = new Signature(3, 4, 280);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.convert2scales();
        }

        private void convert2scales()
        {
            ApplicationSystem s = new ApplicationSystem();
            textBox2.Text = s.convert(textBox1.Text, signature);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.convert2scales();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // read only
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            this.reboot();
        }

        private void reboot()
        {
            comboBox1.Items.Clear();
            Converters c = new Converters();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex != -1)
            {
                ComboItem ci = (ComboItem)this.comboBox2.Items[this.comboBox2.SelectedIndex];
                textBox1.Text = ci.Value;
                label1.Text = ci.ExtraValue;
                // @todo Read the lyrics notations once again instead of caches
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // convert the notations
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // reload the file database
            this.reboot();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
    }
}
