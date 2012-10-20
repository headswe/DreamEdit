namespace DreamEdit
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.text = new System.Windows.Forms.RichTextBox();
            this.box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.box)).BeginInit();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(374, 23);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(365, 296);
            this.text.TabIndex = 0;
            this.text.Text = "";
            // 
            // box
            // 
            this.box.Location = new System.Drawing.Point(53, 37);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(283, 264);
            this.box.TabIndex = 1;
            this.box.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 331);
            this.Controls.Add(this.box);
            this.Controls.Add(this.text);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox text;
        private System.Windows.Forms.PictureBox box;
    }
}