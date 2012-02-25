using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DreamEdit
{
    public partial class string_dialog : Form
    {
        public string_dialog(string msg)
        {
            InitializeComponent();
            label1.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public string getresult()
        {
            return textBox1.Text;
        }
    }
}
