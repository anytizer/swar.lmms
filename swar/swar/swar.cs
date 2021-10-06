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
        public swar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.convert2scales();
        }

        public void convert2scales()
        {
            string sargam = textBox1.Text;

            Replacer r = new Replacer();
            string scales = r.process(sargam);
            textBox2.Text = scales;

            XMLParser xml = new XMLParser();
            string xpt = xml.generate(scales);

            File.WriteAllText(Configurations.ReadWriteDirectory + "/lmms.xpt", xpt);
            File.WriteAllText(Configurations.ReadWriteDirectory + "/notations-english.txt", scales);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.convert2scales();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            Converter c = new Converter();
            foreach(ComboItem ci in c.getConverters())
            {
                comboBox1.Items.Add(new ComboItem()
                {
                    Text = ci.Text,
                    Value = ci.Value,
                });
            }
            
            LyricsReader lr = new LyricsReader();
            lr.load();

            comboBox2.Items.Clear();
            foreach (string filename in lr.getFiles())
            {
                comboBox2.Items.Add(new ComboItem() {
                    Text = filename,
                    Value = lr.lyrics(filename),
                });
            }

            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem ci = (ComboItem)this.comboBox2.Items[this.comboBox2.SelectedIndex];
            textBox1.Text = ci.Value;
            // @todo Read the lyrics notations once again instead of caches
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // convert the notations
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NotesLoader nl = new NotesLoader();
            List<Tone> tones = nl.LoadNotes();

            foreach (Tone t in tones)
            {
                // add button
                // add click handler
                //
            }

        }

        private void notes1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
