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
        public bool isModified = false;
        public bool hasbeenmodified = false; // Best variable ever
        public mainWindow mainForm;
        public textEditor(mainWindow parent,Console C,TabPage P)
        {
            InitializeComponent();
            mainForm = parent;
            this.Dock = DockStyle.Fill;
            editor.Tag = P;
            
            //toolStrip1.Dock = DockStyle.Top;
            // Not even sure what im doing here??
   /*         TabControl tabCon = (TabControl)editor.FindReplace.Window.Controls["tabAll"];
            TabPage bP = new TabPage();
            bP.Controls.Add(new FRtab(mainWindow.info, C, parent));
            bP.Name = "Find in Files";
            bP.Text = bP.Name;
            tabCon.TabPages.Add(bP);*/
        }

        
        private void scintilla2_TextInserted(object sender,  ScintillaNET.TextModifiedEventArgs e)
        {
        
        }

        private void scintilla2_Load(object sender, EventArgs e)
        {
            editor.Lexing.Colorize();
        }

        private void scintilla2_TextChanged(object sender, EventArgs e)
        {
            if (!hasbeenmodified)
            {
                hasbeenmodified = true;
                return;
            }
            TabPage P = (TabPage)editor.Tag;
            isModified = true;
          //  P.Parent.Invalidate();
            
            
        }

        private void scintilla2_KeyDown(object sender, KeyEventArgs e)
        {
        }

     

 
    }
}
