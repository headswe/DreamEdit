using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DreamEdit.DMI
{
    public partial class dmiViewer : UserControl
    {
        Dictionary<String, ImageState> states;
        String show = "";
        String selected_state = "";
        DMimage source;
        public dmiViewer(DMimage source)
        {
            InitializeComponent();
            states = source.getStates();
            imageView.TileSize = new Size(source.width, source.height);
            this.source = source;
            generate_stateview();

        }
        private void generate_stateview()
        {
            int i = 0;
            imageView.LargeImageList = new ImageList();
            imageView.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
            imageView.LargeImageList.ImageSize = new Size(source.width, source.height);
            imageView.Items.Clear();
            foreach (String state in states.Keys)
            {
                ImageState img = states[state];
                imageView.LargeImageList.Images.Add(img.frames[i].directions[2]);
                imageView.Items.Add(new ListViewItem(state, i));
            }
        }

        private void update()
        {
            if (show == "")
            {
                generate_stateview();
            }
            else if (show == "frames")
            {
                imageView.LargeImageList = new ImageList();
                imageView.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
                imageView.LargeImageList.ImageSize = new Size(source.width, source.height);
                imageView.Items.Clear();
                ImageState state = states[selected_state];
                Dictionary<int,ListViewGroup> groups = new Dictionary<int,ListViewGroup>();
                foreach (ImageFrame frame in state.frames)
                {
                    int imageCount = 0;
                    foreach (int i in DMI.Directions.ALL)
                    {
                        if (!frame.directions.ContainsKey(i))
                            continue;
                        ListViewGroup group;
                        if(groups.ContainsKey(i))                       
                        {
                            group = groups[i];
                        }
                        else
                           group = new ListViewGroup(i.ToString());groups[i] = group;
                        imageView.LargeImageList.Images.Add(frame.directions[i]);
                        imageView.Items.Add(new ListViewItem("", imageCount,group));
                        imageCount++;
                        



                    }
                }
                imageView.Groups.AddRange(groups.Values.ToArray());
                imageView.ShowGroups = true;
            }
        }
        private void imageView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem a = imageView.GetItemAt(e.X, e.Y);
            if (a == null)
                return;
            selected_state = a.Text;
            show = "frames";
            update();
        }

        private void imageView_Validating(object sender, CancelEventArgs e)
        {
           
        }
    }
}
