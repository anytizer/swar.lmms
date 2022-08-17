using dtos;
using libraries;
using System;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace swar
{
    public partial class GUIComponentSourceArea : UserControl
    {
        //private string from = ""; // roman_short: S R G M P D N
        private string to = ""; // sargams: // सा रे ग म प ध नि
        private bool split = false;

        private TextBox output_placeholder = new TextBox();
        public GUIComponentSourceArea()
        {
            InitializeComponent();
        }

        internal string sargams()
        {
            return this.textBox1.Text;
        }

        internal void SetSourceNotation(string sargams)
        {
            this.textBox1.Text = sargams;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GUIComponentSourceArea_Load(object sender, EventArgs e)
        {
            this.textBox1.Dock = DockStyle.Fill;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sargams = this.textBox1.Text; //.sargams();

            ApplicationSystem s = new ApplicationSystem();
            string with_comments = s.convert(sargams, this.signature(), this.to, this.split);
            string without_comments = s.no_comments_on_screen(with_comments);

            this.output_placeholder.Text = without_comments; // this.textBox1.Text;
        }

        private Signature signature()
        {
            Signature signature = new Signature(4, 4, 301);

            return signature;
        }

        internal void TranslateOnChange(TextBox textBox)
        {
            this.output_placeholder = textBox;
        }

        private void openSargamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sargams = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SARGAM Notations|notations-*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
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

        private void fromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = System.Windows.Forms.Clipboard.GetText();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}