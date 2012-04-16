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
    public partial class Console : UserControl
    {
        int error_count = 0;
        public Console()
        {
            InitializeComponent();
        }
        public void AppendLink(string str, string hyper)
        {
            hyper = hyper.Replace("\\", "/");
            str = str.Replace("\\", "/");
            console_textbox.InsertLink(str, hyper);
            console_textbox.AppendText("\n");
        }
        public void AppendText(string S)
        {
            if (S.IndexOf(":error:") == -1 && S.IndexOf(":warning:") == -1)
                console_textbox.AppendText(S);
            else
            {
                string[] line = S.Split(':');
                if (line.Count() - 1 == 4)
                    S = line[2] + line[4].Substring(0, line[4].Length - 1) + " \"" + line[3].Substring(1) + "\"" + " in " + line[0] + " at line " + line[1];
                else if (line.Count() - 1 == 3)
                    S = line[2]+":" + line[3].Substring(0, line[3].Length - 1)  + " in " + line[0] + " at line " + line[1];
                else if (line.Count() - 1 == 2)
                {
                    S = line[2] + ":" + line[3].Substring(0, line[3].Length - 1) + " in " + line[0] + " at line " + line[1];
                }
                else
                    S = "STRING TOO LONG";
                S = S.Replace("\\", "/");
                string hyper = line[0] + ":" + line[1];
                hyper = hyper.Replace("\\","/");
                console_textbox.InsertLink(S, hyper);
                console_textbox.AppendText("\n");
                error_count++;
            }
        }
        public void ClearText()
        {
            console_textbox.Clear();
        }
        private void console_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void console_textbox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            mainWindow F = (mainWindow)FindForm();
            string[] lines = e.LinkText.Split('#');
            string name = lines[0];
            lines = lines[1].Split(':');
            string line = lines[lines.Length-1];
            if (lines.Length == 3)
            {
                name = lines[0] + ":" + lines[1];
            }
            else
                name = lines[0];
            name = name.Replace('/', '\\');
            F.link_sent(name, line);
        }
    }
}
