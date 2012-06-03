using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using ICSharpCode.SharpZipLib.BZip2;
using System.Windows.Media;
namespace DreamEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    /*        Stream F = new FileStream("test.dmi", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            PngBitmapDecoder decoder = new PngBitmapDecoder(F,BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default
                );
            BitmapSource sImg;
            Image img = Image.FromStream(F);

            byte[] temp = decoder.Metadata.GetQuery("state");
            List<string> list;*/
       /*     Dictionary<int,string> props = new Dictionary<int,string>();
            foreach(string p in list)
            {
                string id;
                string value;
              byte[] tempbuf;
                MemoryStream P = new MemoryStream();
                MemoryStream temp = new MemoryStream();
                tempbuf = (byte[])p.Id;
                P.Write(p.Id);
                Decompress = new GZipStream(P, CompressionMode.Decompress);
                Decompress.CopyTo(temp);
                id = new String(temp
              //  System.Console.WriteLine(Convert.ToString(p.Id) + ":" + value);
            }*/
           // pictureBox1.Image = img;
        }
    }
}
