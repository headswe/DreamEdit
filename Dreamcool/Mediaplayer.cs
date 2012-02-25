using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
namespace DreamEdit
{
    public partial class Mediaplayer : UserControl
    {
        SoundPlayer player;
        Info info;
        public Mediaplayer(Info info,string filepath)
        {
            InitializeComponent();
            this.info = info;
            player = new SoundPlayer(filepath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (player.IsLoadCompleted)
                player.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
    }
}
