using dtos;
using libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace swar
{
    public partial class KeyboardUserControl : UserControl
    {
        private NotesLoader nl;
        private List<Button> keyboard;
        private List<Button> specialkeys;

        public KeyboardUserControl()
        {
            this.nl = new NotesLoader();
            this.keyboard = new List<Button>();
            this.specialkeys = new List<Button>();
            InitializeComponent();
        }

        private void KeyboardUserControl_Load(object sender, EventArgs e)
        {
            //this.process();
        }

        public List<Button> keys()
        {
            return this.keyboard;
        }

        public void process()
        {
            this.addPianoKeyboard();
            this.addSpecialKeys();
        }

        private void addPianoKeyboard()
        {
            nl.LoadNotes();

            this.Controls.Clear();
            this.keyboard.Clear();

            int x = 0;
            int y = 0;
            foreach (Tone key in nl.tones)
            {
                Button b = new Button();
                b.Text = key.name;
                b.Height = key.tonality.height;
                b.Width = key.tonality.width;
                b.Size = new Size(key.tonality.width, key.tonality.width);
                b.Location = new Point(x, y);

                b.ForeColor = ColorTranslator.FromHtml(key.color);
                b.BackColor = ColorTranslator.FromHtml(key.bgcolor);

                this.Controls.Add(b);
                this.keyboard.Add(b);

                x += key.tonality.width;
            }
        }

        private void addSpecialKeys()
        {
            //EventHandler special = new EventHandler(this._keySpecialClick);
            List<KeyHandler> special_keys = new List<KeyHandler>();
            special_keys.Add(new KeyHandler() { key = "#//", tooltip = "Block" });
            special_keys.Add(new KeyHandler() { key = "|", tooltip = "Division" });
            special_keys.Add(new KeyHandler() { key = ",", tooltip = "Khitka" });
            special_keys.Add(new KeyHandler() { key = "-", tooltip = "Continuation" });
            special_keys.Add(new KeyHandler() { key = "x", tooltip = "Silence" });
            special_keys.Add(new KeyHandler() { key = "NL", tooltip = "New Line" });
            special_keys.Add(new KeyHandler() { key = "DEL", tooltip = "Delete" });

            int x = 700;
            int y = 0;

            foreach (KeyHandler sk in special_keys)
            {
                int square = 40;
                Button b = new Button();
                b.Text = sk.key;
                b.Height = square;
                b.Width = square;
                b.Size = new Size(square, square);
                b.Location = new Point(x, y);

                toolTip1.SetToolTip(b, sk.tooltip);

                x += square + 2;

                //b.ForeColor = ColorTranslator.FromHtml(key.color);
                //b.BackColor = ColorTranslator.FromHtml(key.bgcolor);

                this.Controls.Add(b);
                this.specialkeys.Add(b);
            }
        }

        internal List<Button> special_keys()
        {
            return this.specialkeys;
        }
    }

    public class KeyHandler
    {
        public string key { get; set; }
        public string tooltip { get; set; }
        //public EventHandler handler { get; set; }
    }
}
