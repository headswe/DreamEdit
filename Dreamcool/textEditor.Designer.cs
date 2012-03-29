namespace DreamEdit
{
 
    partial class textEditor
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
            this.scintilla2 = new ScintillaNet.Scintilla();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla2)).BeginInit();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scintilla2
            // 
            this.scintilla2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.scintilla2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scintilla2.ConfigurationManager.CustomLocation = "dm.xml";
            this.scintilla2.ConfigurationManager.Language = "batchs";
            this.scintilla2.Folding.Flags = ScintillaNet.FoldFlag.Box;
            this.scintilla2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.scintilla2.Indentation.ShowGuides = true;
            this.scintilla2.Indentation.SmartIndentType = ScintillaNet.SmartIndent.CPP;
            this.scintilla2.IsBraceMatching = true;
            this.scintilla2.Lexing.Lexer = ScintillaNet.Lexer.Cpp;
            this.scintilla2.Lexing.LexerName = "cpp";
            this.scintilla2.Lexing.LineCommentPrefix = "";
            this.scintilla2.Lexing.StreamCommentPrefix = "";
            this.scintilla2.Lexing.StreamCommentSufix = "";
            this.scintilla2.Location = new System.Drawing.Point(0, 28);
            this.scintilla2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.scintilla2.Margins.Margin0.Width = 40;
            this.scintilla2.Name = "scintilla2";
            this.scintilla2.Size = new System.Drawing.Size(390, 287);
            this.scintilla2.Styles.BraceBad.FontName = "Verdana";
            this.scintilla2.Styles.BraceLight.FontName = "Verdana";
            this.scintilla2.Styles.ControlChar.FontName = "Verdana";
            this.scintilla2.Styles.Default.FontName = "Verdana";
            this.scintilla2.Styles.IndentGuide.FontName = "Verdana";
            this.scintilla2.Styles.LastPredefined.FontName = "Verdana";
            this.scintilla2.Styles.LineNumber.FontName = "Verdana";
            this.scintilla2.Styles.Max.FontName = "Verdana";
            this.scintilla2.TabIndex = 0;
            this.scintilla2.Load += new System.EventHandler(this.scintilla2_Load);
            this.scintilla2.TextChanged += new System.EventHandler<System.EventArgs>(this.scintilla2_TextChanged);
            this.scintilla2.TextInserted += new System.EventHandler<ScintillaNet.TextModifiedEventArgs>(this.scintilla2_TextInserted);
            this.scintilla2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scintilla2_KeyDown);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(387, 0);
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(387, 22);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(387, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            // 
            // textEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.scintilla2);
            this.Name = "textEditor";
            this.Size = new System.Drawing.Size(390, 315);
            ((System.ComponentModel.ISupportInitialize)(this.scintilla2)).EndInit();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNet.Scintilla scintilla2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;

    }
}
