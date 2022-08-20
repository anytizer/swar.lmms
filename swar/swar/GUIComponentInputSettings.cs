using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swar
{
    public partial class GUIComponentInputSettings : UserControl
    {
        public GUIComponentInputSettings()
        {
            InitializeComponent();
        }

        private void GUIComponentInputSettings_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
