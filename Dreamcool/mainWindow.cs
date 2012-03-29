using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
namespace DreamEdit
{

    public partial class mainWindow : Form
    {
        // constants used to hide a checkbox
        public const int TVIF_STATE = 0x8;
        public const int TVIS_STATEIMAGEMASK = 0xF000;
        public const int TV_FIRST = 0x1100;
        public const int TVM_SETITEM = TV_FIRST + 63;
        static public Info info;
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam,
        IntPtr lParam);

        // struct used to set node properties
        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public String lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;

        }
        ImageList image_list = new ImageList();
        public mainWindow()
        {
            InitializeComponent();
            info = new Info(this);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            image_list.Images.Add(BlackFox.Win32.Icons.IconFromExtension("Directory", BlackFox.Win32.Icons.SystemIconSize.Small));
            image_list.Images.Add(BlackFox.Win32.Icons.IconFromExtension(".dm", BlackFox.Win32.Icons.SystemIconSize.Small));
            image_list.Images.Add(BlackFox.Win32.Icons.IconFromExtension(".dmf", BlackFox.Win32.Icons.SystemIconSize.Small));
            image_list.Images.Add(Image.FromFile("gui\\speaker.ico"));
            image_list.Images.Add(BlackFox.Win32.Icons.IconFromExtension(".dmi", BlackFox.Win32.Icons.SystemIconSize.Small));
            image_list.Images.Add(BlackFox.Win32.Icons.IconFromExtension(".dms", BlackFox.Win32.Icons.SystemIconSize.Small));
            image_list.Images.Add(BlackFox.Win32.Icons.IconFromExtension(".dmm", BlackFox.Win32.Icons.SystemIconSize.Small));
            file_list.ImageList = image_list;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menu_1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            men_open.ShowDialog();
            dme_load(men_open.FileName);
        }
        private void close_all_tabs()
        {
                foreach (TabPage P in tabControl1.TabPages)
                {
                    close_tab(P);
                }
        }
        private bool ask_save_all()
        {
            DialogResult res = MessageBox.Show("Do you want to save all open tabs?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (res == DialogResult.Yes)
            {
                foreach (TabPage P in tabControl1.TabPages)
                {
                    save_tab(P);
                }
            }
            else if (res == DialogResult.No)
            {
                return true;
            }
            else return false;
            return true;
        }
        private bool ask_save_tab(TabPage P)
        {
            DialogResult res = MessageBox.Show("Do you want to save this tab?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (res == DialogResult.Yes)
            {
                    save_tab(P);
            }
            else if (res == DialogResult.No)
            {
                return true;
            }
            else return false;
            return true;
        }
        private void reset()
        {
            if (!ask_save_all())
                return;
            close_all_tabs();
            info = new Info(this);
            file_list.Nodes.Clear();
            buildToolStripMenuItem.Enabled = false;
        }
        private void men_open_FileOk(object sender, CancelEventArgs e)
        {
            if (info.dme_Loaded)
                reset();
            if (this.men_open.FileName.IndexOf(".dme") != -1)
            {
                return;
            }

        }
        private void dme_load(string filename)
        {
            info.dme_path = filename;
            info.load_dme();
            if (info.dme_Loaded)
                buildToolStripMenuItem.Enabled = true;
            System.Console.WriteLine(info.dme_path);
        }
        private void mainWindow_Load(object sender, EventArgs e)
        {

            hide_console();
        }

        private void text_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void file_list_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            fileInfo F = (fileInfo)e.Node.Tag;
            if (e.Node.Level == 0)
                HideCheckBox(e.Node);
            else if (F == null || F.Extension != ".dm" && F.Extension != ".dmf")
            {
                HideCheckBox(e.Node);
            }
            e.DrawDefault = true;
            
        }
        private void HideCheckBox(TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvi));
            Marshal.StructureToPtr(tvi, lparam, false);
            SendMessage(this.file_list.Handle, TVM_SETITEM, IntPtr.Zero, lparam);
        }

        private void file_list_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void file_list_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            fileInfo F = (fileInfo)e.Node.Tag;
            open_tab(F);
        }

        private void savemenu_Click(object sender, EventArgs e)
        {

            save_all();
        }
        private void save_all()
        {
            foreach (TabPage P in tabControl1.TabPages)
            {
                save_tab(P);
            }
        }
        private void save_tab(TabPage P, string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            file.Write(P.Controls[0].Controls["scintilla2"].Text);
            textEditor UC = (textEditor)P.Controls[0];
            UC.isModified = false;
            tabControl1.Invalidate();
            file.Close();
        }
        private void save_tab(TabPage P)
        {
            fileInfo F = (fileInfo)P.Tag;
            System.IO.StreamWriter file = new System.IO.StreamWriter(F.FullPath);
            file.Write(P.Controls[0].Controls["scintilla2"].Text);
            F.Text = P.Controls[0].Controls["scintilla2"].Text;
            textEditor UC = (textEditor)P.Controls[0];
            UC.isModified = false;
            tabControl1.Invalidate();
            file.Close();

        }           // ;
        private void open_tab(string name)
        {
            foreach (TabPage B in tabControl1.TabPages)
            {
                fileInfo fi = (fileInfo)B.Tag;
                if (fi.InternalPath == name)
                {
                    tabControl1.SelectTab(B);
                    return;
                }
            }
            fileInfo F = info.files[info.dirs + "\\" + name];
            if (F == null)
                throw new NullReferenceException("Could not find file " + info.dirs + "\\" + name);
            TabPage P = new TabPage(F.FileName + F.Extension);
            P.Controls.Add(new textEditor(this, console));
            P.Controls[0].Controls["scintilla2"].Text = F.Text;
            P.Controls[0].Size = tabControl1.Size;
            P.Controls[0].Dock = DockStyle.Fill;
            ScintillaNet.Scintilla note = (ScintillaNet.Scintilla)P.Controls[0].Controls["scintilla2"];
            note.UndoRedo.EmptyUndoBuffer();
            P.Controls[0].Tag = P;
            P.Tag = F;
            tabControl1.TabPages.Add(P);
            tabControl1.SelectTab(P);
        }
        private void open_tab(fileInfo name)
        {
            if (name == null)
                return;
            foreach (TabPage B in tabControl1.TabPages)
            {
                fileInfo fi = (fileInfo)B.Tag;
                if (fi == name)
                {
                    tabControl1.SelectTab(B);
                    return;
                }
            }
            fileInfo F = name;
            if (F == null)
                throw new NullReferenceException("Could not find file " + F.FullPath);
            if (info.sound_Filetypes.Contains(F.Extension))
            {
                TabPage V = new TabPage(F.FileName + F.Extension);
                V.Controls.Add(new Mediaplayer(info, F.FullPath));
                tabControl1.TabPages.Add(V);
                tabControl1.SelectTab(V);
                return;
            }
            if (F.Extension != ".dm")
                return;
            TabPage P = new TabPage(F.FileName + F.Extension);
            P.Controls.Add(new textEditor(this, console));
            P.Controls[0].Controls["scintilla2"].Text = F.Text;
            P.Controls[0].Size = tabControl1.Size;
            P.Controls[0].Dock = DockStyle.Fill;
            ScintillaNet.Scintilla note = (ScintillaNet.Scintilla)P.Controls[0].Controls["scintilla2"];
            note.UndoRedo.EmptyUndoBuffer();
            P.Controls[0].Tag = P;
            P.Tag = F;
            tabControl1.TabPages.Add(P);
            tabControl1.SelectTab(P);
        }
        public void open_tab(string name, int line)
        {
            ScintillaNet.Scintilla chat;
            if(name.Contains(info.dir))
                name = name.Remove(0,info.dir.Length+1);
            foreach (TabPage B in tabControl1.TabPages)
            {
                fileInfo fi = (fileInfo)B.Tag;
                if (fi.InternalPath == name)
                {
                    tabControl1.SelectTab(B);
                    chat = (ScintillaNet.Scintilla)tabControl1.SelectedTab.Controls[0].Controls["scintilla2"];
                    chat.GoTo.Line(line);
                    return;
                }
            }
            
            if (!info.files.ContainsKey(info.dir + "\\" + name))
                throw new NullReferenceException("Could not find file " + info.dir + "\\" + name);
            fileInfo F = info.files[info.dir + "\\" + name];
            if (F.Extension != ".dm")
                return;
            if (F == null)
                throw new NullReferenceException("Could not find file " + info.dir + "\\" + name);
            TabPage P = new TabPage(F.FileName + F.Extension);
            P.Controls.Add(new textEditor(this, console));
            P.Controls[0].Controls["scintilla2"].Text = F.Text;
            P.Controls[0].Size = tabControl1.Size;
            P.Controls[0].Dock = DockStyle.Fill;
            ScintillaNet.Scintilla note = (ScintillaNet.Scintilla)P.Controls[0].Controls["scintilla2"];
            note.UndoRedo.EmptyUndoBuffer();
            P.Controls[0].Tag = P;
            P.Tag = F;
            tabControl1.TabPages.Add(P);
            tabControl1.SelectTab(P);
            chat = (ScintillaNet.Scintilla)tabControl1.SelectedTab.Controls[0].Controls["scintilla2"];
            chat.GoTo.Line(Convert.ToInt32(line));
        }
        public void link_sent(string name, string line)
        {
            open_tab(name, Convert.ToInt32(line));
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                for (int x = 0; x < tabControl1.TabCount; x++)
                {
                    Rectangle R = tabControl1.GetTabRect(x);

                    if (R.Contains(e.Location))
                    {
                        tab_menu.Tag = tabControl1.TabPages[x];
                        Point F = tabControl1.PointToScreen(e.Location);
                        tab_menu.Show(F);

                    }
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                for (int x = 0; x < tabControl1.TabCount; x++)
                {
                    Rectangle R = tabControl1.GetTabRect(x);

                    if (R.Contains(e.Location))
                    {
                        TabPage _tabPage = tabControl1.TabPages[x];
                        textEditor F = (textEditor)_tabPage.Controls[0];
                        if (!F.isModified)
                        {
                            close_tab(_tabPage);
                        }
                        else
                        {
                            if (!ask_save_tab(_tabPage))
                                return;
                            close_tab(_tabPage);
                        }
                    }
                }
            }
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage P = (TabPage)tab_menu.Tag;
            save_tab(P);
            tabControl1.TabPages.Remove(P);
        }
        private void close_tab(TabPage P)
        {
            tabControl1.TabPages.Remove(P);
        }
        private void closeWithoutSaveingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage P = (TabPage)tab_menu.Tag;
            tabControl1.TabPages.Remove(P);
        }

        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (tabControl1.Focused)
                {
                    if (tabControl1.SelectedTab != null)
                        save_tab(tabControl1.SelectedTab);
                }
                else
                {
                    save_all();
                }
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                if (tabControl1.Focused)
                {
                    if (tabControl1.SelectedTab != null)
                    {
                        ScintillaNet.Scintilla pad = (ScintillaNet.Scintilla)tabControl1.SelectedTab.Controls[0].Controls["scintilla2"];
                    }
                }
                else
                {
                    //  ScintillaNet.FindReplaceDialog dialog = new ScintillaNet.FindReplaceDialog();
                    // dialog.ShowDialog();
                    //  ScintillaNet.FindReplace FF;


                }
            }
        }
        private void hide_console()
        {
            if (!console.Visible)
                return;
            console.Visible = false;
            splitContainer1.Size = new Size(splitContainer1.Width, splitContainer1.Height + console.Height + 5);

        }
        private void show_console()
        {
            if (console.Visible)
                return;
            console.Visible = true;
            splitContainer1.Size = new Size(splitContainer1.Width, splitContainer1.Height - console.Height - 5);

        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_all();
            show_console();
            backgroundWorker1.RunWorkerAsync();
            buildToolStripMenuItem.Enabled = false;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string skey = @"SOFTWARE\Classes\byond\DefaultIcon";
            RegistryKey k = Registry.LocalMachine.OpenSubKey(skey);
            string path = (string)k.GetValue("");
            path = Path.GetDirectoryName(path);
            Process compiler = new Process();
            compiler.StartInfo.FileName = path + "\\dm.exe";
            compiler.StartInfo.Arguments = info.dme_path;
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.RedirectStandardError = true;
            compiler.StartInfo.CreateNoWindow = true;
            backgroundWorker1.ReportProgress(0, "| Compiling " + Path.GetFileName(info.dme_path) + " |");

            compiler.OutputDataReceived += output_recv;
            compiler.Start();
            compiler.BeginOutputReadLine();
            compiler.WaitForExit();

        }
        delegate void BindTextBoxControl(string text);
        void output_recv(object sender, DataReceivedEventArgs e)
        {

            string T = (string)e.Data;
            if (T != null)
            {
                backgroundWorker1.ReportProgress(0, T);
            }
        }
        private void UpdateTextbox(string _Text)
        {
            //console.Text += _Text+"\n";
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            console.AppendText((string)e.UserState + "\n");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buildToolStripMenuItem.Enabled = true;
        }

        private void toggleConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (console.Visible)
                hide_console();
            else
                show_console();
        }

        private void viewObjectTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objTree F = new objTree(info, this);
            F.Show();
        }

        private void file_list_AfterCheck(object sender, TreeViewEventArgs e)
        {
            fileInfo F = (fileInfo)e.Node.Tag;
            if (F == null)
                throw new NullReferenceException("Node tag is null.");
            F.Checked = !F.Checked;
            info.save_dme();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _TextBrush;

            // Get the item from the collection.
            TabPage _TabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _TabBounds = tabControl1.GetTabRect(e.Index);
            textEditor F = (textEditor)_TabPage.Controls[0];
            if (F.isModified)
                _TextBrush = new SolidBrush(Color.Red);
            else
                _TextBrush = new System.Drawing.SolidBrush(e.ForeColor);
            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.

                g.FillRectangle(Brushes.LightGray, e.Bounds);
            }


            // Use our own font. Because we CAN.
            Font _TabFont = new Font(e.Font.FontFamily, (float)9, FontStyle.Regular, GraphicsUnit.Pixel);
            //Font fnt = new Font(e.Font.FontFamily, (float)7.5, FontStyle.Bold);

            // Draw string. Center the text.
            StringFormat _StringFlags = new StringFormat();
            _StringFlags.Alignment = StringAlignment.Center;
            _StringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(tabControl1.TabPages[e.Index].Text, _TabFont, _TextBrush,
                         _TabBounds, new StringFormat(_StringFlags));

        }
        private fileInfo addFile(TreeNode p, string name)
        {
            TreeNode tree = (TreeNode)file_list_menu.Tag;
            string path = tree.FullPath;
            path = path.Replace('/', '\\');
            if (path.IndexOf('\\') != -1)
            {
                path = path.Substring(path.IndexOf('\\'));
                path = info.dir + path + "\\" + name;
            }
            else
                path = info.dir + name;
            if (File.Exists(path))
                return null;
            StreamWriter B = File.CreateText(path);
            B.Close();
            fileInfo fInfo = new fileInfo(path, tree.FullPath.Replace('/', '\\').Substring(tree.FullPath.IndexOf('/')));
            if (info.dme_Loaded)
            {
                info.files.Add(path, fInfo);
                info.save_dme();
            }
            return fInfo;
        }
        private fileInfo addFile(string p, string name)
        {
            TreeNode tree = (TreeNode)file_list_menu.Tag;
            string path = p;
            path = path.Replace('/', '\\');
            if (path.IndexOf('\\') != -1)
            {
                path = path.Substring(path.IndexOf('\\'));
                path = info.dir + path + "\\" + name;
            }
            else
                path = info.dir + name;
            if (File.Exists(path))
                return null;
            StreamWriter B = File.CreateText(path);
            B.Close();
            fileInfo fInfo = new fileInfo(path,p);
            if (info.dme_Loaded)
            {
                info.files.Add(path, fInfo);
                info.save_dme();
            }
            return fInfo;
        }
        private void addNewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string_dialog S = new string_dialog("Filename:");
            S.ShowDialog();
            if (S.DialogResult == DialogResult.Cancel)
                return;
            string name = S.getresult();
            string ext = Path.GetExtension(name);
            if (ext == "" || !info.isdm(ext) && !info.issound(ext))
            {
                MessageBox.Show("Wrong fileending");
                return;
            }
            TreeNode tree = (TreeNode)file_list_menu.Tag;
            string path = tree.FullPath;
            path = path.Replace('/', '\\');
            if (path.IndexOf('\\') != -1)
            {
                path = path.Substring(path.IndexOf('\\'));
                path = info.dir + path + "\\" + name;
            }
            else
                path = info.dir + name;
            if (File.Exists(path))
                return;
            StreamWriter B = File.CreateText(path);
            B.Close();
            info.files.Add(path, new fileInfo(path, tree.FullPath.Replace('/', '\\').Substring(tree.FullPath.IndexOf('/'))));
            TreeNode node = new TreeNode(name);
            node.Tag = info.files[path];
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            tree.Nodes.Add(node);
            info.save_dme();
        }

        private void file_list_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                fileInfo f = (fileInfo)e.Node.Tag;
                if (f == null) // directory
                {
                    Point F = file_list.PointToScreen(e.Location);
                    file_list_menu.Tag = e.Node;
                    file_list_menu.Show(F);
                }
                else
                {
                    return;
                }


            }
            else
                return;
        }

        private void addNewDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string_dialog S = new string_dialog("Directory name:");
            S.ShowDialog();
            if (S.DialogResult == DialogResult.Cancel)
                return;
            string name = S.getresult();
            /*   string ext = Path.GetExtension(name);
               if (ext == "" || !info.isdm(ext) && !info.issound(ext))
               {
                   MessageBox.Show("Wrong fileending");
                   return;
               }*/
            TreeNode tree = (TreeNode)file_list_menu.Tag;
            string path = tree.FullPath;
            //  path = path.Replace('/', '\\');
            if (path.IndexOf('\\') != -1)
            {
                path = path.Substring(path.IndexOf('\\'));
                path = info.dir + path + "\\" + name;
            }
            else
                path = info.dir + name;
            if (Directory.Exists(path))
                return;
            Directory.CreateDirectory(path);

            string internalpath = tree.FullPath.Substring(tree.FullPath.Replace('\\', '/').IndexOf('/')) + "/" + name;
            TreeNode newnode = new TreeNode(name);
            tree.Nodes.Add(newnode);
            info.dirs.Add(name);
            info.dirsfull[internalpath] = name;
            info.save_dme();
        }

        private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFRdialog();
        }
        public void openFRdialog()
        {
            FRdialog f = new FRdialog(info, console);
            //f.ShowDialog();
        }
        private void newDMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string_dialog S = new string_dialog("Enivorment name:");
            S.ShowDialog();
            if (S.DialogResult == DialogResult.Cancel)
                return;
            string name = S.getresult();
            string path = folderBrowserDialog1.SelectedPath;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            fileInfo f = addFile(path, name + ".dm");
            fileInfo fdme = addFile(path, name + ".dme");
            StreamWriter P = new StreamWriter(path+"\\"+name+"\\" + name + ".dme");
            P.Write(dme_string);
            P.Close();
            P = new StreamWriter(path + "\\" + name + "\\" + name + ".dm");
            P.Write(dm_string);
            P.Close();
            File.AppendAllText(path+"\\"+name+"\\" + name + ".dme", "\n #include \""+name+".dm\"\n // END_INCLUDE");
          //  this.reset();

        }

        private void tab_menu_Opening(object sender, CancelEventArgs e)
        {

        }
        string dme_string = File.ReadAllText("res\\default.dme");
        string dm_string = File.ReadAllText("res\\default.dm");

        private void gotoLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage P = tabControl1.SelectedTab;
            if (P == null)
                return;
            ScintillaNet.Scintilla note = (ScintillaNet.Scintilla)tabControl1.SelectedTab.Controls[0].Controls["scintilla2"];
            if (note == null)
                return;
            note.GoTo.ShowGoToDialog();
        }

        private void file_list_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array a = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (a != null)
                {
                    string s = a.GetValue(0).ToString();
                    if (Path.GetExtension(s) == ".dme")
                    {
                        mainWindow_DragDrop(sender, e);
                        return;
                    }
                    if (!info.dm_Filetypes.Contains(Path.GetExtension(s)) && !info.sound_Filetypes.Contains(Path.GetExtension(s)) && !info.image_Filetypes.Contains(Path.GetExtension(s)))
                    {
                        return;
                    }
                     //to be implemented.

                    this.Activate();        // in the case Explorer overlaps this form
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error in DragDrop function: " + ex.Message);

                // don't show MessageBox here - Explorer is waiting !
            }
        }

        private void mainWindow_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array a = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (a != null)
                {
                    string s = a.GetValue(0).ToString();
                    if (info.dme_Loaded)
                        return;
                    else if (Path.GetExtension(s) != ".dme")
                        return;
                    info.dme_path = s;
                    info.load_dme();
                   // this.BeginInvoke(m_DelegateOpenFile, new Object[] { s });

                    this.Activate();        // in the case Explorer overlaps this form
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error in DragDrop function: " + ex.Message);

                // don't show MessageBox here - Explorer is waiting !
            }
        }
        private void mainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }


        public TreeView get_tree()
        {
            return file_list;
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage _tabPage in tabControl1.TabPages)
            {
                textEditor F = (textEditor)_tabPage.Controls[0];
                if (F.isModified)
                {
                    if (ask_save_all())
                        return;
                    else
                        e.Cancel = true;
                    return;
                }
            }
        }
    }
}
