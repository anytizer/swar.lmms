using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swar
{
    public partial class GUIComponentConversionArea : UserControl
    {
        public GUIComponentConversionArea()
        {
            InitializeComponent();
        }

        internal string GetTranslations()
        {
            return this.textBox2.Text;
        }

        internal void SetTranslations(string translations)
        {
            this.textBox2.Text = translations;
        }

        private void GUIComponentConversionArea_Load(object sender, EventArgs e)
        {
            this.textBox2.Dock = DockStyle.Fill;
        }

        public TextBox OutputArea()
        {
            return this.textBox2;
        }

        private void revealInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", configs.Configurations.ReadWriteDirectory);
        }
    }
}
