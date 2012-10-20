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
            this.editor = new ScintillaNet.Scintilla();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.editor)).BeginInit();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editor.ConfigurationManager.CustomLocation = "dm.xml";
            this.editor.ConfigurationManager.Language = "cpp";
            this.editor.Folding.Flags = ScintillaNet.FoldFlag.Box;
            this.editor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.editor.Indentation.ShowGuides = true;
            this.editor.Indentation.SmartIndentType = ScintillaNet.SmartIndent.CPP;
            this.editor.IsBraceMatching = true;
            this.editor.Lexing.Lexer = ScintillaNet.Lexer.Cpp;
            this.editor.Lexing.LexerName = "cpp";
            this.editor.Lexing.LineCommentPrefix = "";
            this.editor.Lexing.StreamCommentPrefix = "";
            this.editor.Lexing.StreamCommentSufix = "";
            this.editor.Location = new System.Drawing.Point(0, 28);
            this.editor.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.editor.Margins.Margin0.Width = 40;
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(390, 287);
            this.editor.Styles.BraceBad.FontName = "Verdana";
            this.editor.Styles.BraceLight.FontName = "Verdana";
            this.editor.Styles.ControlChar.FontName = "Verdana";
            this.editor.Styles.Default.FontName = "Verdana";
            this.editor.Styles.IndentGuide.FontName = "Verdana";
            this.editor.Styles.LastPredefined.FontName = "Verdana";
            this.editor.Styles.LineNumber.FontName = "Verdana";
            this.editor.Styles.Max.FontName = "Verdana";
            this.editor.TabIndex = 0;
            this.editor.Load += new System.EventHandler(this.scintilla2_Load);
            this.editor.TextChanged += new System.EventHandler<System.EventArgs>(this.scintilla2_TextChanged);
            this.editor.TextInserted += new System.EventHandler<ScintillaNet.TextModifiedEventArgs>(this.scintilla2_TextInserted);
            this.editor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scintilla2_KeyDown);
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
            this.Controls.Add(this.editor);
            this.Name = "textEditor";
            this.Size = new System.Drawing.Size(390, 315);
            ((System.ComponentModel.ISupportInitialize)(this.editor)).EndInit();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNet.Scintilla editor;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;

    }
}
