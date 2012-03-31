using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DreamEdit
{
    public partial class FRdialog : UserControl
    {
        Info info;
        Console console;
        mainWindow mainWindow;
        List<lineFound> arrStr = new List<lineFound>();
        public FRdialog(Info info, Console c, mainWindow m)
        {
            this.info = info;
            console = c;
            mainWindow = m;
            InitializeComponent();
        }

        struct lineFound
        {
            public string str;
            public string file;
            public int line;
        }
       
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            worker.WorkerReportsProgress = true;
            int totalFiles = 0;
            foreach (fileInfo F in info.files.Values)
            {
                if (F.Extension != ".dm")
                    continue;
                totalFiles++;
            }
            int doneFiles = 0;
            foreach (fileInfo F in info.files.Values)
            {
                if (F.Extension != ".dm")
                    continue;
                StreamReader reader = new StreamReader(F.FullPath);
                int line = 1;
                while (!reader.EndOfStream)
                {
                    string strLine = reader.ReadLine();
                    int x = strLine.IndexOf(textBox1.Text);
                    int y = strLine.LastIndexOf(textBox1.Text);
                    if (x >= 0)
                    {
                        lineFound n = new lineFound();
                        n.str = textBox1.Text;
                        n.line = line;
                        n.file = F.FullPath;
                        arrStr.Add(n);
                    }
                    if (y >= 0)
                    {
                        lineFound n = new lineFound();
                        n.str = textBox1.Text;
                        n.line = line;
                        n.file = F.FullPath;
                        arrStr.Add(n);
                    }
                    line++;
                }
                doneFiles++;
                worker.ReportProgress((doneFiles / totalFiles) * 100);
            }

        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button1.Enabled = false;
            mainWindow.show_console();
            arrStr = new List<lineFound>();
            worker.RunWorkerAsync();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox1.Enabled = true;
            button1.Enabled = true;
            progressBar1.Value = 0;
            if (arrStr.Count == 0)
                console.AppendText("\"" + textBox1.Text + "\" was not found anywhere in the project.");
            else
                foreach (lineFound f in arrStr)
                    console.AppendLink("Found \"" + f.str + "\" in " + f.file + " on line "+f.line, f.file + ":" + f.line);
        }
    }
}
