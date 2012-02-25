using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace DreamEdit
{
    public class fileInfo
    {
        public String FileName;
        public String DirPath;
        public String Extension;
        public String InternalPath;
        public String FullPath { get { return DirPath + "\\" + FileName + Extension; } }
        public String Text;
        public bool Checked = false;
        public fileInfo(string FileName, string Path, string Extension)
        {
            this.FileName = FileName;
            this.DirPath = Path;
            this.Extension = Extension;
            if (Extension == ".dm")
            {
                StreamReader F = new StreamReader(FullPath);
                Text = F.ReadToEnd();
                F.Close();
            }
        }
        public fileInfo(string FullPath,string InternalPath,bool Checked = true)
        {
            this.Checked = Checked;
            FileName = Path.GetFileNameWithoutExtension(FullPath);
            DirPath = Path.GetDirectoryName(FullPath);
            Extension = Path.GetExtension(FullPath);
            this.InternalPath = InternalPath;
            if (Extension == ".dm")
            {
                StreamReader F = new StreamReader(FullPath);
                Text = F.ReadToEnd();
                F.Close();
            }
        }
        
    }
}
