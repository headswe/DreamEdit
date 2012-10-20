using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.IO;
using FreeImageAPI;
using FreeImageAPI.Metadata;
using DreamEdit.DMI;
namespace DreamEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FreeImageAPI.FreeImageBitmap img = new FreeImageAPI.FreeImageBitmap("wires.dmi", FreeImageAPI.FREE_IMAGE_FORMAT.FIF_PNG, FreeImageAPI.FREE_IMAGE_LOAD_FLAGS.DEFAULT);
            MetadataModel model = img.Metadata.List[0];
            string desc = "";
            desc += model.List[0].Value;
            text.Text = desc;
           // box.Image = img.ToBitmap();
            DMimage img2 = new DMimage("wires.dmi");
            Dictionary<String, ImageState> states = img2.getStates();
            ImageState img3 = states["wire_0"];
            ImageFrame img4 = img3.frames[0];
            box.Image = img4.directions[1];


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
