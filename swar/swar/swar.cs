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
            signature = new Signature() { 
                beat_nominator = 2,
                beat_denominator = 4,
                beat_quantization = 1 / 4,
                tempo = 140,
            };
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
            // read only
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            s.reboot(comboBox1, comboBox2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.comboBox2.SelectedIndex != -1)
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
            s.reboot(comboBox1, comboBox2);
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
                    }
    }
}
