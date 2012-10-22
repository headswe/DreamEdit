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
            this.editor = new ScintillaNET.Scintilla();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.editor)).BeginInit();
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
            this.editor.ConfigurationManager.LoadOrder = ScintillaNET.Configuration.ConfigurationLoadOrder.CustomUserBuiltIn;
            this.editor.Folding.Flags = ScintillaNET.FoldFlag.Box;
            this.editor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.editor.Indentation.ShowGuides = true;
            this.editor.Indentation.SmartIndentType = ScintillaNET.SmartIndent.CPP;
            this.editor.IsBraceMatching = true;
            this.editor.Lexing.Lexer = ScintillaNET.Lexer.Cpp;
            this.editor.Lexing.LexerName = "cpp";
            this.editor.Lexing.LineCommentPrefix = "";
            this.editor.Lexing.StreamCommentPrefix = "";
            this.editor.Lexing.StreamCommentSufix = "";
            this.editor.Location = new System.Drawing.Point(0, 25);
            this.editor.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.editor.Margins.Margin0.Width = 40;
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(390, 290);
            this.editor.TabIndex = 0;
            this.editor.Load += new System.EventHandler(this.scintilla2_Load);
            this.editor.TextInserted += new System.EventHandler<ScintillaNET.TextModifiedEventArgs>(this.scintilla2_TextInserted);
            this.editor.TextChanged += new System.EventHandler(this.scintilla2_TextChanged);
            this.editor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scintilla2_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(390, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // textEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.editor);
            this.Name = "textEditor";
            this.Size = new System.Drawing.Size(390, 315);
            ((System.ComponentModel.ISupportInitialize)(this.editor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScintillaNET.Scintilla editor;
        private System.Windows.Forms.ToolStrip toolStrip1;

    }
}
