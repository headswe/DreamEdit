using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DreamEdit
{
    public partial class textEditor : UserControl
    {
        public bool ismodified = false;
        public bool hasbeenmodified = false; // Best variable ever
        public textEditor()
        {
            InitializeComponent();
        }

        private void scintilla2_TextInserted(object sender, ScintillaNet.TextModifiedEventArgs e)
        {

        }

        private void scintilla2_Load(object sender, EventArgs e)
        {
            scintilla2.Lexing.Colorize();
        }

        private void scintilla2_TextChanged(object sender, EventArgs e)
        {
            if (!hasbeenmodified)
            {
                hasbeenmodified = true;
                return;
            }
            TabPage P = (TabPage)this.Tag;
            ismodified = true;
            P.Parent.Invalidate();
            
        }
    }
}
