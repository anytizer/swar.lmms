using configs;
using dtos;
using libraries;
using System;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace swar
{
    public partial class SwarConverter : Form
    {
        private ApplicationSystem s;
        private Signature signature;
        //private string from = ""; // roman_short: S R G M P D N
        private string to = ""; // sargams: // सा रे ग म प ध नि
        private bool split = false;
        private string filename = "";

        public SwarConverter()
        {
            InitializeComponent();
            this.s = new ApplicationSystem();
            this.signature = new Signature(4, 4, 280);
        }

        private void convert2scales()
        {
            string sargams = textBox1.Text;

            ApplicationSystem s = new ApplicationSystem();
            string with_comments = s.convert(sargams, this.signature, this.to, this.split);
            string without_comments = s.no_comments_on_screen(with_comments);

            textBox2.Text = without_comments;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.convert2scales();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // read only
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.to = Scales.RomanShort;
            this.convert2scales();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.to = Scales.Sargam;
            this.convert2scales();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.to = Scales.EnglishScale;
            this.convert2scales();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.split = checkBox1.Checked;
            this.convert2scales();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sargams = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Notations|notations-*.txt";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.filename = ofd.FileName;
                    this.title(this.filename);

                    StreamReader sr = new StreamReader(ofd.FileName);
                    sargams = sr.ReadToEnd();
                    sr.Close();
                }
                catch (SecurityException ex)
                {
                }
            }

            this.textBox1.Text = sargams;
        }

        private void title(string something)
        {
            this.Text = something;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.filename!="")
            {
                File.WriteAllText(this.filename, this.textBox1.Text);
            }
        }

        private void newNotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.filename = "";
            this.title(this.filename);

            this.textBox1.Text = "";
        }
    }
}
