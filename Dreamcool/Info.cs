using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace DreamEdit
{
    public class Info
    {
        public string dme_path;
        public string dir;
        public TreeNode root;
        public Dictionary<string,fileInfo> files = new Dictionary<string,fileInfo>();
        public List<string> dirs = new List<string>();
        public Dictionary<string, string> dirsfull = new Dictionary<string, string>();
        public bool dme_Loaded = false;
        public List<string> dm_Filetypes = new List<string>();
        public List<string> sound_Filetypes = new List<string>();
        public List<string> image_Filetypes = new List<string>();
        public bool isdebug = false;
        mainWindow mainWindow = null;
        public Info(mainWindow mainWindow)
        {
            dm_Filetypes.Add(".dm");
            dm_Filetypes.Add(".dmi");
            dm_Filetypes.Add(".dmf");
            dm_Filetypes.Add(".dmm");
            sound_Filetypes.Add(".wav");
            sound_Filetypes.Add(".mid");
            sound_Filetypes.Add(".midi");
            sound_Filetypes.Add(".mod");
            sound_Filetypes.Add(".it");
            sound_Filetypes.Add(".s3m");
            sound_Filetypes.Add(".xm");
            sound_Filetypes.Add(".oxm");
            sound_Filetypes.Add(".ogg");
            sound_Filetypes.Add(".raw");
            sound_Filetypes.Add(".wma");
            sound_Filetypes.Add(".aiff");
            this.mainWindow = mainWindow;
        }
        public void load_dme()
        {
            if (dme_Loaded)
            {
                dirs = new List<string>();
                dirsfull = new Dictionary<string, string>();
                files = new Dictionary<string, fileInfo>();
                root = new TreeNode();
                dme_Loaded = false;
            }
            dir = Path.GetDirectoryName(dme_path);
            root = new TreeNode(Path.GetFileNameWithoutExtension(dme_path));
            StreamReader tr = new StreamReader(dme_path);
            while (tr.EndOfStream == false)
            {
                string temp = tr.ReadLine();
                string[] lines = temp.Split(' ');
                if (lines[0] == "#include")
                {
                    string line = lines[1];
                    if (lines.Length > 2)
                    {
                        for (int i = 2; i < lines.Length; i++)
                        {
                            line += " " + lines[i];

                        }
                    }
                    line = line.Substring(1,line.Length-2);
                    files[dir + "\\" + line] = new fileInfo(dir + '\\' + line,line);
                    System.Console.WriteLine(dir+'\\'+line);
                }
                else if (lines.Length - 1 >= 1 && lines[1] == "FILE_DIR")
                {
                    string line = lines[2];
                    if (line == ".")
                        continue;
                    if (lines.Length > 3)
                    {
                        for (int i = 3; i < lines.Length; i++)
                        {
                            line += " " + lines[i];

                        }
                    }
                    line = line.Substring(1, line.Length - 2);
                    if (line.IndexOf('/') == -1)
                    {
                        dirs.Add(line);
                        dirsfull[line] = line;
                    }
                    else
                    {
                        lines = line.Split('/');
                        dirs.Add(lines[lines.Length - 1]);
                        dirsfull[line] = lines[lines.Length - 1];
                    }

                }
                
            }
            popTree(dir, root);
            TreeView T = mainWindow.get_tree();
            T.Nodes.Add(root);
            dme_Loaded = true;
            tr.Close();
            save_dme();
        }
        public void save_dme()
        {
            if (dme_path == null)
                return;
            string contents = "// DM Environment file for " + Path.GetFileName(dme_path) + ".\n";
            contents += "// All manual changes should be made outside the BEGIN_ and END_ blocks. \n // New source code should be placed in .dm files: choose File/New --> Code File. \n // BEGIN_INTERNALS \n // END_INTERNALS \n // BEGIN_FILE_DIR \n";
            contents += "#define FILE_DIR .\n";
            foreach (string S in dirsfull.Keys)
            {
                //string B = S.Replace('\\','//');
                contents += "#define FILE_DIR \"" + S + "\"\n";
            }
            contents += "// END_FILE_DIR\n\n";
            contents += "// BEGIN_PREFERENCES\n";
            if (isdebug)
                contents += "#define DEBUG\n";
            contents += "// END_PREFERENCES\n\n";
            contents += "// BEGIN_INCLUDE\n";
            foreach (fileInfo F in files.Values)
            {
                if (!F.Checked)
                    continue;
                contents += "#include \"" + F.InternalPath + "\"\n";
            }
            contents += "// END_INCLUDE\n";
            System.IO.StreamWriter file = new System.IO.StreamWriter(dme_path);
            file.Write(contents);
            file.Close();

        }
        public bool checktype(string ext)
        {
            foreach (string k in dm_Filetypes)
            {
                if (k == ext)
                    return true;
            }
            return false;
        }
        public bool issound(string ext)
        {
            foreach (string k in sound_Filetypes)
            {
                if (k == ext)
                    return true;
            }
            return false;
        }
        public bool isdm(string ext)
        {
            foreach (string k in dm_Filetypes)
            {
                if (k == ext)
                    return true;
            }
            return false;
        }
        public bool isimage(string ext)
        {
            foreach (string k in image_Filetypes)
            {
                if (k == ext)
                    return true;
            }
            return false;
        }
        private void popTree(string dir, TreeNode node)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                if (!dirs.Contains(d.Name))
                    continue; // it's not in the DME ignore it.
                TreeNode t = new TreeNode(d.Name);
                t.ImageIndex = 0;
                popTree(d.FullName, t);
                node.Nodes.Add(t);
            }
            foreach (FileInfo f in directory.GetFiles())
            {
                // create a new node
                if (!isdm(f.Extension) && !issound(f.Extension))
                    continue;
                TreeNode t = new TreeNode(f.Name);
                fileInfo FI = null;
                if (!files.ContainsKey(f.FullName))
                {
                    string paths = Path.GetDirectoryName(f.FullName);
                    paths =  paths.Substring(paths.IndexOf(this.dir+"\\")+this.dir.Length+1);
                    files[f.FullName] = new fileInfo(f.FullName,paths+"\\"+f.Name,false);
                    FI = files[f.FullName];
                }
                else
                {
                    t.Checked = true;
                    FI = files[f.FullName];
                }
                if (FI == null)
                    throw new ArgumentNullException();
                t.Tag = FI;
                if (isdm(f.Extension))
                    if (f.Extension == ".dmf")
                    {
                        t.ImageIndex = 2;
                        t.SelectedImageIndex = 2;
                    }
                    else if (f.Extension == ".dmi")
                    {
                        t.ImageIndex = 4;
                        t.SelectedImageIndex = 4;
                    }
                    else
                    {
                        t.ImageIndex = 1;
                        t.SelectedImageIndex = 1;
                    }
                else if (issound(f.Extension))
                {
                    t.ImageIndex = 3;
                    t.SelectedImageIndex = 3;
                }
                // add it to the "master"
                node.Nodes.Add(t);
            }

        }
    }
}
