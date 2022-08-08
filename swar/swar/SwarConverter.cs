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
        public SwarConverter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            guiComponentSourceArea1.TranslateOnChange(guiComponentConversionArea1.OutputArea());
        }

        private void guiComponentConversionArea1_Load(object sender, EventArgs e)
        {

        }

        private void guiComponentSourceArea1_Load(object sender, EventArgs e)
        {

        }

        private void guiComponentOuputSettings1_Load(object sender, EventArgs e)
        {

        }

        private void guiComponentInputSettings1_Load(object sender, EventArgs e)
        {

        }
    }
}
