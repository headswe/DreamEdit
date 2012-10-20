using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DreamEdit
{
    static class Recent
    {
        static public List<String> recent_list;
        static public List<ToolStripMenuItem> recent_list_menu = new List<ToolStripMenuItem>();

        static public List<string> getRecent()
        {
            List<string> values = new List<string>();
            List<string> tempStorage = new List<string>();
            if (!File.Exists("recent.cfg"))
            {
                File.CreateText("recent.cfg");
            }
            StreamReader reader = new StreamReader("recent.cfg");
            for (int x = 0; x < 5; x++)
            {
                if (reader.EndOfStream)
                    break;
                values.Add(reader.ReadLine());
            }
            foreach (string item in values)
            {
                if (!File.Exists(item))
                    tempStorage.Add(item); // you can't modify a list inside a foreach loop..
            }
            foreach (string item in tempStorage)
            {
                values.Remove(item);
            }
            reader.Close();
            values.Reverse();
            return values;
        }
        static public void saveRecent(mainWindow window)
        {
            StreamWriter writer = new StreamWriter("recent.cfg");
            foreach (String item in recent_list)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }
        static public void addToRecent(string filename,mainWindow window)
        {
            ToolStripMenuItem temp = null;
            if (!recent_list.Contains(filename))
            {
                if (recent_list.Count >= 5)
                {
                    recent_list.RemoveAt(4);
                    recent_list.Add(filename);
                }
                else
                    recent_list.Add(filename);
            }
            else
            {

                foreach (ToolStripMenuItem item in recent_list_menu)
                {
                    if (item.Text == filename)
                        temp = item; break;
                }
            }
            if (temp != null)
            {
                recent_list_menu.Remove(temp);
                window.MenuFile.DropDownItems.Remove(temp);
            }
            temp = new ToolStripMenuItem(filename, null, window.recent_Click, (String)Path.GetFileName(filename));
            foreach (ToolStripMenuItem item in recent_list_menu)
            {
                window.MenuFile.DropDownItems.Remove(item);
            }
            recent_list_menu.Add(temp);
            recent_list_menu.Reverse();
            foreach (ToolStripMenuItem item in recent_list_menu)
            {
                window.MenuFile.DropDownItems.Add(item);
            }
            saveRecent(window);

        }
    }
}
