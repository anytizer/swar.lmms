namespace swar
{
    partial class SwarConverter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwarConverter));
            this.guiComponentConversionArea1 = new swar.GUIComponentConversionArea();
            this.guiComponentSourceArea1 = new swar.GUIComponentSourceArea();
            this.guiComponentInputSettings1 = new swar.GUIComponentInputSettings();
            this.guiComponentOuputSettings1 = new swar.GUIComponentOuputSettings();
            this.SuspendLayout();
            // 
            // guiComponentConversionArea1
            // 
            this.guiComponentConversionArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.guiComponentConversionArea1.Location = new System.Drawing.Point(332, 126);
            this.guiComponentConversionArea1.Name = "guiComponentConversionArea1";
            this.guiComponentConversionArea1.Size = new System.Drawing.Size(673, 379);
            this.guiComponentConversionArea1.TabIndex = 18;
            this.guiComponentConversionArea1.Load += new System.EventHandler(this.guiComponentConversionArea1_Load);
            // 
            // guiComponentSourceArea1
            // 
            this.guiComponentSourceArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.guiComponentSourceArea1.Location = new System.Drawing.Point(10, 126);
            this.guiComponentSourceArea1.Name = "guiComponentSourceArea1";
            this.guiComponentSourceArea1.Size = new System.Drawing.Size(311, 379);
            this.guiComponentSourceArea1.TabIndex = 19;
            this.guiComponentSourceArea1.Load += new System.EventHandler(this.guiComponentSourceArea1_Load);
            // 
            // guiComponentInputSettings1
            // 
            this.guiComponentInputSettings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.guiComponentInputSettings1.Location = new System.Drawing.Point(10, 3);
            this.guiComponentInputSettings1.Name = "guiComponentInputSettings1";
            this.guiComponentInputSettings1.Size = new System.Drawing.Size(309, 117);
            this.guiComponentInputSettings1.TabIndex = 20;
            this.guiComponentInputSettings1.Load += new System.EventHandler(this.guiComponentInputSettings1_Load);
            // 
            // guiComponentOuputSettings1
            // 
            this.guiComponentOuputSettings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.guiComponentOuputSettings1.Location = new System.Drawing.Point(332, 12);
            this.guiComponentOuputSettings1.Name = "guiComponentOuputSettings1";
            this.guiComponentOuputSettings1.Size = new System.Drawing.Size(673, 108);
            this.guiComponentOuputSettings1.TabIndex = 21;
            this.guiComponentOuputSettings1.Load += new System.EventHandler(this.guiComponentOuputSettings1_Load);
            // 
            // SwarConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 519);
            this.Controls.Add(this.guiComponentOuputSettings1);
            this.Controls.Add(this.guiComponentInputSettings1);
            this.Controls.Add(this.guiComponentSourceArea1);
            this.Controls.Add(this.guiComponentConversionArea1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SwarConverter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SWAR Converter for LMMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private GUIComponentConversionArea guiComponentConversionArea1;
        private GUIComponentSourceArea guiComponentSourceArea1;
        private GUIComponentInputSettings guiComponentInputSettings1;
        private GUIComponentOuputSettings guiComponentOuputSettings1;
    }
}

