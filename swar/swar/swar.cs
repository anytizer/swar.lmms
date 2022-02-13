using configs;
using dtos;
using libraries;
using System;
using System.Windows.Forms;

namespace swar
{
    public partial class swar : Form
    {
        private ApplicationSystem s;
        private Signature signature;
        private Permissions acl;

        public swar()
        {
            InitializeComponent();
            this.s = new ApplicationSystem();
            this.signature = new Signature(3, 4, 280);

            /**
             * Will be overwritten externally.
             */
            this.acl = new Permissions();
            acl.SetACLMode(FeaturesUnlocked.FREE);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from = "";
            string to = "";
            this.convert2scales(from, to);
        }

        private void convert2scales(string from, string to)
        {
            bool authority = acl.HasAuthority(PermissionsList.CONVERT_SCALES);
            if (authority)
            {
                ApplicationSystem s = new ApplicationSystem();
                string with_comments = s.convert(textBox1.Text, signature);
                string without_comments = s.no_comments_on_screen(with_comments);
                textBox2.Text = without_comments;
            }
            else
            {
                MessageBox.Show("No authority!");
            }
        }

        internal void permissions(Permissions acl)
        {
            this.acl = acl;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string from = "";
            string to = "";
            this.convert2scales(from, to);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // read only
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.acl = new Permissions();
            this.acl.SetACLMode(FeaturesUnlocked.PREMIUM); // @todo Read from license

            bool authority_xpt = acl.HasAuthority(PermissionsList.SAVE_XPTS);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
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
                b.Click += new EventHandler(this._PianoKeyClick);
            }

            foreach (Button b in keyboardUserControl1.special_keys())
            {
                b.Click += new EventHandler(this._SpecialKeyClick);
            }
        }

        private void _PianoKeyClick(object sender, EventArgs e)
        {
            Button s = sender as Button;
            // MessageBox.Show("Child reading: "+sender.ToString());
            this.textBox1.Text += " " + s.Text;
        }

        private void _SpecialKeyClick(object sender, EventArgs e)
        {
            string add = "";
            Button s = sender as Button;
            switch (s.Text)
            {
                case SpecialKeys.BLOCK_SEPARATOR:
                    add = "\r\n\r\n#//\r\n\r\n";
                    break;
                case SpecialKeys.COMMA:
                    add = s.Text;
                    break;
                case SpecialKeys.PIPE:
                    add = SpecialKeys.DIVISION_SEPARATOR_FORMATTER;
                    break;
                case SpecialKeys.SILENCE:
                    add = SpecialKeys.SILENCE_FORMATTER;
                    break;
               case SpecialKeys.CONTINUATION:
                    add = " - ";
                    break;
                case SpecialKeys.NEWLINE:
                    add = "\r\n";
                    break;
                case SpecialKeys.DELETE:
                    add = "";
                    break;
                case SpecialKeys.LOWER_OCTAVE_NOTATION:
                    add = s.Text;
                    break;
                case SpecialKeys.HIGHER_OCTAVE_NOTATION:
                    add = s.Text;
                    break;
                default:
                    break;
            }

            this.textBox1.Text += add;
        }
    }
}
