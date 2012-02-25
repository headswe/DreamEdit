using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using Parser;
namespace DreamEdit
{
    public partial class objTree : Form
    {
        public Info info;
        private mainWindow owner;

        struct lineinfo
        {
            public string type;
            public string _ref;
            public string line ;
            public string name;
            public string value;
        }
        public objTree(Info i,mainWindow k)
        {
            info = i;
            owner = k;
            InitializeComponent();
            loadtree();
        }
        private void loadtree()
        {
            TreeNode objroot = new TreeNode("Universe");
            int totalFiles = 0;
            List<fileInfo> files = new List<fileInfo>();
            foreach (fileInfo F in info.files.Values)
            {
                if (F.Extension != ".dm")
                    continue;
                totalFiles++;
                files.Add(F);
            }
   //         int doneFiles = 0;
            DMParser P = new DMParser();
            foreach (fileInfo F in files)
            {
                FileStream f = new FileStream(F.FullPath, FileMode.Open);
                if (f == null) continue;
                P.parseFile(f, F.InternalPath);
                f.Close();
            }
            foreach (DMToken token in P.tokens)
            {
                string[] paths = token.pathToString().Split('/');
                TreeNode curNode = objroot;
                foreach (string s in paths)
                {
                    if (s == "")
                        continue;
                    if (curNode.Nodes.ContainsKey(s))
                    { curNode = curNode.Nodes[s]; continue; }
                    else
                    {
                        TreeNode n = new TreeNode(s);
                        n.Name = s;
                        curNode.Nodes.Add(n);
                        n.Tag = token;
                        curNode = n;
                        continue;
                    }
                        
                }
            }
            foreach (TreeNode n in objroot.Nodes)
            {
               // if (n.Nodes.Count == 0)
                 //   continue;
                treeView1.Nodes.Add(n);
            }
        }
        private lineinfo parsestring(string line)
        {
            lineinfo i = new lineinfo();
            if(line.IndexOf("</") == -1)
            {
                i.type = line.Substring(line.IndexOf('<')+1,line.IndexOf(' ')-line.IndexOf('<')-1);
                if (i.type == "var f")
                    i.type = "var";//best hack
            int fpos = line.IndexOf('\"');
            int spos = line.IndexOf('\"',fpos+1);
            i._ref = line.Substring(fpos+1,spos-fpos-1);
            i.line = i._ref.Substring(i._ref.IndexOf(':')+1);
            i._ref = i._ref.Substring(0, i._ref.IndexOf(':'));
            i.name = line.Substring(line.IndexOf('>')+1,line.IndexOf('\r')-line.IndexOf('>')-1);

            }
            else if (line.IndexOf("</val>") != -1)
            {
                i.type = "val";
                int fpos = line.IndexOf('\"');
                int spos = line.IndexOf('\"',fpos+1);
                i._ref = line.Substring(fpos+1,spos-fpos);
                i.line = i._ref.Substring(i._ref.IndexOf(':') + 1, 1);
                i._ref = i._ref.Substring(0, i._ref.IndexOf(':'));
                int firstpos = line.IndexOf('\"', spos+1);
                int lastpos = line.IndexOf('\"',firstpos+1);
                i.value = line.Substring(firstpos+1,lastpos-firstpos-1);
            }
            else
            {
                i.type = line;
            }
            return i;
        }
        private void new_node()
        {
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DMToken token = (DMToken)e.Node.Tag;
            System.Console.WriteLine(token.filename + "at line:" + token.lineno);
            owner.open_tab(token.filename, token.lineno);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
      /*  private void loadtree()
        {
            TreeNode objroot = new TreeNode("obj");
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
                TreeNode curnode = null;
                while (!reader.EndOfStream)
                {
                    string Str = reader.ReadLine();
                    TreeNode f = objroot;
                    if (Str.Contains("obj/") && !Str.Contains("(") && !Str.Contains("proc") && !Str.Contains("var") && Str != "")
                    {
                        string[] arr = Str.Split('/');
                        f = objroot;
                        foreach (String S in arr)
                        {
                            if (S == "obj" || S == "" || S == "\t")
                                continue;
                            if (f.Nodes.ContainsKey(S))
                            {
                                f = f.Nodes[S];
                                curnode = f;
                            }
                            else
                            {
                                TreeNode b = new TreeNode(S);
                                b.Name = S;
                                f.Nodes.Add(b);
                                f = b;
                                curnode = b;
                            }
                        }
                        string peek = reader.ReadLine();
                        TreeNode varnode;

                        if (curnode.Nodes.ContainsKey("var"))
                            varnode = curnode.Nodes["var"];
                        else
                        {
                            varnode = new TreeNode("var");
                            varnode.Name = "var";
                            curnode.Nodes.Add(varnode);
                        }
                        bool done = false;
                        while (!reader.EndOfStream && !done)
                        {
                            if(peek == "" && peek == "\t")
                                peek = reader.ReadLine();
                            if (!peek.Contains("proc") || peek != "" || peek != "\t" )
                            {
                                if (peek.Contains("obj/") && !peek.Contains("var"))
                                    break;
                                TreeNode b;
                                b = new TreeNode(peek);
                                b.Name = peek;
                                varnode.Nodes.Add(b);
                            }
                            else
                            {
                                break;
                            }
                            if (reader.EndOfStream)
                                break;
                            peek = reader.ReadLine();
                        }
                    }
                    else if (Str.Contains('(') || Str.Contains("proc"))
                    {
                        curnode = null;
                        continue;
                    }
                    else if (Str.Contains("var/") && curnode != null)
                    {
                        string[] arr = Str.Split('/');
                        TreeNode b;
                        if (curnode.Nodes.ContainsKey("var"))
                            curnode = curnode.Nodes["var"];
                        else
                        {
                            curnode = new TreeNode("var");
                            curnode.Name = "var";
                        }
                        b = new TreeNode(Str);
                        b.Name = Str;
                        curnode.Nodes.Add(b);
                    }
                }
            }
            treeView1.Nodes.Add(objroot);
        }
       private void loadtree_old()
       {
            string skey = @"SOFTWARE\Classes\byond\DefaultIcon";
            RegistryKey k = Registry.LocalMachine.OpenSubKey(skey);
            string path = (string)k.GetValue("");
            path = Path.GetDirectoryName(path);
            Process compiler = new Process();
            compiler.StartInfo.FileName = path + "\\dm.exe";
            compiler.StartInfo.Arguments = "-o "+info.dme_path;
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.Start();
            herp = compiler.StandardOutput.ReadToEnd();
            System.Console.WriteLine(herp);
            compiler.WaitForExit();
            string[] lines = herp.Split('\n');

            TreeNode cur_node = null;
            lineinfo cur_info = new lineinfo();
            TreeNode cur_val = null;
            foreach (string line in lines)
            {
                if (line.IndexOf('<') == -1)
                {
                    continue;
                }
                if (cur_node == null || cur_info.type == null)
                {
                    cur_info = parsestring(line);
                    cur_node = new TreeNode(cur_info.name);
                    cur_node.Name = cur_info.name;
                    TreeNode tempnode = new TreeNode("Variables");
                    cur_node.Nodes.Add(tempnode);
                    tempnode = new TreeNode("Procs");
                    cur_node.Nodes.Add(tempnode);
                    cur_node.Tag = cur_info;
                }
                else if (cur_info.type != "var" && line.IndexOf("</" + cur_info.type + ">") != -1)
                {
                    if (cur_node.Text != "obj")
                    {
                        if (cur_info.type == "obj")
                        {
                            treeView1.Nodes["obj"].Nodes.Add(cur_node);
                        }
                    }
                    else
                        treeView1.Nodes.Add(cur_node);
                    cur_info.type = null;
                    cur_node = null;
                }
                else
                {
                    lineinfo temp = parsestring(line);
                    if (temp.type == "var")
                    {
                        cur_val = new TreeNode(temp.name);
                        cur_val.Tag = temp;
                    }
                    else if (temp.type == "val" && cur_val != null)
                    {
                        lineinfo t = (lineinfo)cur_val.Tag;
                        t.value = temp._ref;
                        cur_node.Nodes[0].Nodes.Add(cur_val);
                        cur_val = null;
                    }
                    else if (temp.type == "proc" && cur_val != null)
                    {
                        TreeNode P = new TreeNode(temp.name);
                        P.Tag = temp;
                        cur_node.Nodes[1].Nodes.Add(P);

                    }
                }
            }
        }*/
    }
}
