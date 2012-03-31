namespace DreamEdit
{
    partial class mainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newDMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savemenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewObjectTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAndReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.men_open = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.file_list = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tab_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeWithoutSaveingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.file_list_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.work_bar = new System.Windows.Forms.ProgressBar();
            this.console = new DreamEdit.Console();
            this.panel1.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tab_menu.SuspendLayout();
            this.file_list_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menu);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 23);
            this.panel1.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.AllowDrop = true;
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_1,
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.sourceToolStripMenuItem});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(974, 23);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            this.menu.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainWindow_DragDrop);
            this.menu.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainWindow_DragEnter);
            // 
            // menu_1
            // 
            this.menu_1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDMEToolStripMenuItem,
            this.openToolStripMenuItem,
            this.savemenu});
            this.menu_1.Name = "menu_1";
            this.menu_1.Size = new System.Drawing.Size(37, 19);
            this.menu_1.Text = "File";
            // 
            // newDMEToolStripMenuItem
            // 
            this.newDMEToolStripMenuItem.Name = "newDMEToolStripMenuItem";
            this.newDMEToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.newDMEToolStripMenuItem.Text = "New DME";
            this.newDMEToolStripMenuItem.Click += new System.EventHandler(this.newDMEToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openToolStripMenuItem.Text = "Open DME";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // savemenu
            // 
            this.savemenu.Name = "savemenu";
            this.savemenu.Size = new System.Drawing.Size(131, 22);
            this.savemenu.Text = "Save All";
            this.savemenu.Click += new System.EventHandler(this.savemenu_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleConsoleToolStripMenuItem,
            this.viewObjectTreeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toggleConsoleToolStripMenuItem
            // 
            this.toggleConsoleToolStripMenuItem.Name = "toggleConsoleToolStripMenuItem";
            this.toggleConsoleToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.toggleConsoleToolStripMenuItem.Text = "Toggle Console";
            this.toggleConsoleToolStripMenuItem.Click += new System.EventHandler(this.toggleConsoleToolStripMenuItem_Click);
            // 
            // viewObjectTreeToolStripMenuItem
            // 
            this.viewObjectTreeToolStripMenuItem.Name = "viewObjectTreeToolStripMenuItem";
            this.viewObjectTreeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.viewObjectTreeToolStripMenuItem.Text = "View Object Tree";
            this.viewObjectTreeToolStripMenuItem.Click += new System.EventHandler(this.viewObjectTreeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findAndReplaceToolStripMenuItem,
            this.gotoLineToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // findAndReplaceToolStripMenuItem
            // 
            this.findAndReplaceToolStripMenuItem.Name = "findAndReplaceToolStripMenuItem";
            this.findAndReplaceToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.findAndReplaceToolStripMenuItem.Text = "Find in files";
            this.findAndReplaceToolStripMenuItem.Click += new System.EventHandler(this.findAndReplaceToolStripMenuItem_Click);
            // 
            // gotoLineToolStripMenuItem
            // 
            this.gotoLineToolStripMenuItem.Name = "gotoLineToolStripMenuItem";
            this.gotoLineToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.gotoLineToolStripMenuItem.Text = "Goto Line";
            this.gotoLineToolStripMenuItem.Click += new System.EventHandler(this.gotoLineToolStripMenuItem_Click);
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildToolStripMenuItem});
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(55, 19);
            this.sourceToolStripMenuItem.Text = "Source";
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Enabled = false;
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.buildToolStripMenuItem.Text = "Build";
            this.buildToolStripMenuItem.Click += new System.EventHandler(this.buildToolStripMenuItem_Click);
            // 
            // men_open
            // 
            this.men_open.Filter = "DME|*.dme";
            this.men_open.FileOk += new System.ComponentModel.CancelEventHandler(this.men_open_FileOk);
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(766, 253);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // file_list
            // 
            this.file_list.AllowDrop = true;
            this.file_list.CheckBoxes = true;
            this.file_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_list.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.file_list.Location = new System.Drawing.Point(0, 0);
            this.file_list.Name = "file_list";
            this.file_list.Size = new System.Drawing.Size(194, 253);
            this.file_list.TabIndex = 0;
            this.file_list.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.file_list_AfterCheck);
            this.file_list.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.file_list_DrawNode);
            this.file_list.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.file_list_AfterSelect);
            this.file_list.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.file_list_NodeMouseClick);
            this.file_list.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.file_list_NodeMouseDoubleClick);
            this.file_list.DragDrop += new System.Windows.Forms.DragEventHandler(this.file_list_DragDrop);
            this.file_list.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainWindow_DragEnter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AllowDrop = true;
            this.splitContainer1.Panel1.Controls.Add(this.file_list);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(972, 257);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 1;
            // 
            // tab_menu
            // 
            this.tab_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.closeWithoutSaveingToolStripMenuItem});
            this.tab_menu.Name = "tab_menu";
            this.tab_menu.Size = new System.Drawing.Size(185, 48);
            this.tab_menu.Opening += new System.ComponentModel.CancelEventHandler(this.tab_menu_Opening);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // closeWithoutSaveingToolStripMenuItem
            // 
            this.closeWithoutSaveingToolStripMenuItem.Name = "closeWithoutSaveingToolStripMenuItem";
            this.closeWithoutSaveingToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.closeWithoutSaveingToolStripMenuItem.Text = "Close without saving";
            this.closeWithoutSaveingToolStripMenuItem.Click += new System.EventHandler(this.closeWithoutSaveingToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // file_list_menu
            // 
            this.file_list_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewFileToolStripMenuItem,
            this.addNewDirectoryToolStripMenuItem});
            this.file_list_menu.Name = "file_list_menu";
            this.file_list_menu.Size = new System.Drawing.Size(172, 48);
            // 
            // addNewFileToolStripMenuItem
            // 
            this.addNewFileToolStripMenuItem.Name = "addNewFileToolStripMenuItem";
            this.addNewFileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addNewFileToolStripMenuItem.Text = "Add new file";
            this.addNewFileToolStripMenuItem.Click += new System.EventHandler(this.addNewFileToolStripMenuItem_Click);
            // 
            // addNewDirectoryToolStripMenuItem
            // 
            this.addNewDirectoryToolStripMenuItem.Name = "addNewDirectoryToolStripMenuItem";
            this.addNewDirectoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addNewDirectoryToolStripMenuItem.Text = "Add new directory";
            this.addNewDirectoryToolStripMenuItem.Click += new System.EventHandler(this.addNewDirectoryToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 368);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(972, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // work_bar
            // 
            this.work_bar.Location = new System.Drawing.Point(2, 369);
            this.work_bar.Name = "work_bar";
            this.work_bar.Size = new System.Drawing.Size(100, 21);
            this.work_bar.TabIndex = 4;
            this.work_bar.Visible = false;
            // 
            // console
            // 
            this.console.AllowDrop = true;
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.console.Location = new System.Drawing.Point(2, 284);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(965, 100);
            this.console.TabIndex = 2;
            this.console.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainWindow_DragDrop);
            this.console.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainWindow_DragEnter);
            // 
            // mainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 390);
            this.Controls.Add(this.work_bar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.console);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "mainWindow";
            this.Text = "DreamEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainWindow_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainWindow_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tab_menu.ResumeLayout(false);
            this.file_list_menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menu_1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog men_open;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TreeView file_list;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem savemenu;
        private System.Windows.Forms.ContextMenuStrip tab_menu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeWithoutSaveingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleConsoleToolStripMenuItem;
        private Console console;
        private System.Windows.Forms.ToolStripMenuItem viewObjectTreeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip file_list_menu;
        private System.Windows.Forms.ToolStripMenuItem addNewFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAndReplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDMEToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem gotoLineToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ProgressBar work_bar;
    }
}

