namespace DreamEdit.DMI
{
    partial class dmiViewer
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
            this.imageView = new System.Windows.Forms.ListView();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // imageView
            // 
            this.imageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageView.Location = new System.Drawing.Point(0, 27);
            this.imageView.Name = "imageView";
            this.imageView.Size = new System.Drawing.Size(826, 457);
            this.imageView.TabIndex = 0;
            this.imageView.TileSize = new System.Drawing.Size(32, 32);
            this.imageView.UseCompatibleStateImageBehavior = false;
            this.imageView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageView_MouseDoubleClick);
            this.imageView.Validating += new System.ComponentModel.CancelEventHandler(this.imageView_Validating);
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(826, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // dmiViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageView);
            this.Controls.Add(this.menu);
            this.Name = "dmiViewer";
            this.Size = new System.Drawing.Size(826, 419);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView imageView;
        private System.Windows.Forms.MenuStrip menu;
    }
}
