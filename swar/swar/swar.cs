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

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox2.SelectedIndex = 0;

            this.reboot();
        }

        private void reboot()
        {
            Converters c = new Converters();

            comboBox1.Items.Clear();
            foreach (ComboItem ci in c.getSourceFormats())
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

            comboBox3.Items.Clear();
            foreach (ComboItem beat in c.beats())
            {
                comboBox3.Items.Add(beat);
            }
            
            comboBox4.Items.Clear();
            foreach (ComboItem tempo in c.tempos())
            {
                comboBox4.Items.Add(tempo);
            }            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // convert the notations
            if (this.comboBox1.SelectedIndex != -1)
            {
                ComboItem ci = (ComboItem)this.comboBox1.Items[this.comboBox1.SelectedIndex];
                MessageBox.Show(ci.Text);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex != -1)
            {
                ComboItem ci = (ComboItem)this.comboBox2.Items[this.comboBox2.SelectedIndex];
                
                textBox1.Text = ci.Value; // further!
                label1.Text = ci.ExtraValue;
                // @todo Read the lyrics notations once again instead of caches
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // reload the file database
            this.reboot();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox3.SelectedIndex != -1)
            {
                ComboItem ci = (ComboItem)this.comboBox3.Items[this.comboBox3.SelectedIndex];
                MessageBox.Show(ci.Text);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox4.SelectedIndex != -1)
            {
                ComboItem ci = (ComboItem)this.comboBox4.Items[this.comboBox4.SelectedIndex];
                MessageBox.Show(ci.Text);
            }
        }
    }
}
