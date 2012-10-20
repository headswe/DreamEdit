using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace DreamEdit.DMI
{
    public class DMimage
    {
        public DMimage(String Filename)
        {
            DMIParser parser = new DMIParser();
            parser.parse(new FileStream(Filename, FileMode.Open, FileAccess.Read));
            states = parser.states;
            width = parser.width;
            height = parser.height;
        }
        public Dictionary<String, ImageState> getStates()
        {
            return states;
        }
        private Dictionary<String, ImageState> states;
        public int width = 0;
        public int height = 0;
    }
    public class ImageState
    {
        public List<ImageFrame> frames;
    }
    public class ImageFrame
    {
        public Dictionary<int, Bitmap> directions;
        public int delay;
    }
}
