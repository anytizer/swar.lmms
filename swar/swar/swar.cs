﻿using dtos;
using libraries;
using System;
using System.Windows.Forms;

namespace swar
{
    public partial class swar : Form
    {
        private ApplicationSystem s;
        private Signature signature;

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
            comboBox3.SelectedIndex = 0;

            comboBox4.Items.Clear();
            foreach (ComboItem tempo in c.tempos())
            {
                comboBox4.Items.Add(tempo);
            }
            comboBox4.SelectedIndex = 0;
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
                //MessageBox.Show(ci.Text);
                this.updateSignature();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox4.SelectedIndex != -1)
            {
                ComboItem ci = (ComboItem)this.comboBox4.Items[this.comboBox4.SelectedIndex];
                //MessageBox.Show(ci.Text);
                this.updateSignature();
            }
        }

        private void updateSignature()
        {
            // @todo Handle update signature
            // responsive pattern
            return;

            // ComboItem _beat = (ComboItem)this.comboBox3.Items[this.comboBox3.SelectedIndex];
            // ComboItem _tempo = (ComboItem)this.comboBox4.Items[this.comboBox4.SelectedIndex];
            // 
            // int nominator = Helpers.ParseNominator(_beat.Value);
            // int demoninator = Helpers.ParseDenominator(_beat.Value);
            // int tempo = Helpers.ParseTempo(_tempo.Value);
            // 
            // this.signature = new Signature(nominator, demoninator, tempo);
        }

        private void keyboardUserControl1_Load(object sender, EventArgs e)
        {
            keyboardUserControl1.process();
            foreach (Button b in keyboardUserControl1.keys())
            {
                b.Click += new EventHandler(this._keyClick);
            }

            // keyboardUserControl1.addSpecialKeys();
            foreach (Button b in keyboardUserControl1.special_keys())
            {
                b.Click += new EventHandler(this._SpecialKeyClick);
            }
        }

        private void _keyClick(object sender, EventArgs e)
        {
            Button s = sender as Button;
            // MessageBox.Show("Child reading: "+sender.ToString());
            this.textBox1.Text += " " + s.Text;
        }

        private void _SpecialKeyClick(object sender, EventArgs e)
        {
            string add = "";
            Button s = sender as Button;
            switch(s.Text)
            {
                case "#//":
                    add = "\r\n\r\n#//\r\n\r\n";
                    break;
                case ",":
                    add = s.Text;
                    break;
                case "|":
                    add = " | ";
                    break;
                case "x":
                    add = " x ";
                    break;
                case "-":
                    add = " - ";
                    break;
                case "NL":
                    add = "\r\n\r\n";
                    break;
                case "DEL":
                    add = "";
                    break;
                default:
                    break;
            }

            this.textBox1.Text += add;
        }
    }
}
