namespace DreamEdit
{
    partial class Console
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.console_textbox = new RichTextBoxLinks.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // console_textbox
            // 
            this.console_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console_textbox.BulletIndent = 5;
            this.console_textbox.Location = new System.Drawing.Point(-2, -2);
            this.console_textbox.Name = "console_textbox";
            this.console_textbox.ReadOnly = true;
            this.console_textbox.Size = new System.Drawing.Size(972, 80);
            this.console_textbox.TabIndex = 0;
            this.console_textbox.Text = "";
            this.console_textbox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.console_textbox_LinkClicked);
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.console_textbox);
            this.Name = "Console";
            this.Size = new System.Drawing.Size(968, 90);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBoxLinks.RichTextBoxEx console_textbox;

    }
}
