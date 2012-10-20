using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FreeImageAPI;
using FreeImageAPI.Metadata;
using System.Text.RegularExpressions;
using System.Drawing;
namespace DreamEdit.DMI
{
    class DMIParser
    {
        public Dictionary<String, ImageState> states;
        public int width;
        public int height;
        int dmi_width;

        int dmi_height;
        int pixel_x;
        int pixel_y;
        FreeImageBitmap img;
        public void parse(FileStream source)
        {
            img = new FreeImageBitmap(source);
            dmi_width = img.Width;
            dmi_height = img.Height;
            MetadataModel model = img.Metadata.List[0];
            string metaData = model.List[0].Value.ToString();
            List<ImageInfoBlock> nodes = praseMetaData(metaData);


            String state_name = "";

            List<int> state_delay = new List<int>();

            int state_frames = 0;
            int state_directions = 0;
            Boolean had_state = false;

            this.states = new Dictionary<String, ImageState>();
          //  Enu<ImageInfoBlock> it = nodes.GetEnumerator();
            for (int i = 0; i < nodes.Count; i++)
            {
                ImageInfoBlock block = nodes[i];
                if (block.key == "dirs")
                {
                    Int32.TryParse(block.value, out state_directions);
                }
                else if (block.key == "frames")
                {
                    Int32.TryParse(block.value, out state_frames);
                }
                else if (block.key == "delay")
                {
                    foreach(String S in block.value.Split(','))
                    {
                        int x;
                        Int32.TryParse(S, out x);
                        state_delay.Add(x);

                    }
                }
                else if (block.key == "version")
                {
                    continue;
                }
                else if (block.key == "width")
                {
                    Int32.TryParse(block.value, out width);
                }
                else if (block.key == "height")
                {
                    Int32.TryParse(block.value, out height);
                }
                if (had_state) if(block.key == "state" || i == nodes.Count - 1)
                {
                    if (state_frames == 0 || state_directions == 0)
                    {
                        throw new IOException(".DMI metadata malformed");
                    }
                    if (state_delay.Count == 0)
                    {
                        while (state_delay.Count < state_frames)
                        {
                            state_delay.Add(1);
                        }
                    }
                    if (state_delay.Count != state_frames)
                    {
                        throw new IOException(".DMI metadata malformed");
                    }
                    ImageState state = generateSpriteState(state_frames, state_directions, state_delay);

                    // intern state_name to make string comparison more efficient
                    if(!states.ContainsKey(state_name))
                        states.Add(state_name, state); // add state to the sprite
                    state_frames = 0;
                    state_directions = 0;
                    state_delay.Clear();
                    had_state = false;
                }
                if (block.key == "state")
                {
                    state_name = block.value.Substring(1, block.value.Length - 2);
                    had_state = true;
                }
            }

        }

        private ImageState generateSpriteState(int frames, int directions, List<int> delays)
        {
        ImageState state = new ImageState();
		state.frames = new List<ImageFrame>();
		
    	// Extract the width of the full image(not the tiles)
        int base_width = dmi_width;

        for(int framei = 0; framei < frames; framei++)
        {
            // Prepare a new frame to insert into our state
            ImageFrame frame = new ImageFrame();
            frame.directions = new Dictionary<int,System.Drawing.Bitmap>();
            
            // This array simply maps tile indices to directions.
            // For example, the first tile in the frame would be the direction SOUTH.
            int[] dirs = new int[] {Directions.SOUTH, Directions.NORTH, Directions.EAST, Directions.WEST, Directions.SOUTHEAST, Directions.SOUTHWEST, Directions.NORTHEAST, Directions.NORTHWEST};

            if(directions != 1 && directions != 4 && directions != 8) {
            	throw new IOException(".DMI metadata malformed");
            }
            
            // Go over all directions and insert them into our frame
            for(int i=0; i < directions; i++) {
            	// Find out which direction the next tile will be
                int next_dir = dirs[i];
                
            	// If we're at the end of the buffer on the right, go to the next line
                if(pixel_x >= base_width)
                {
                    pixel_x = 0;
                    pixel_y = pixel_y + height;
                }
                System.Drawing.Bitmap image;
                image = img.Copy(new Rectangle(pixel_x, pixel_y, width, height)).ToBitmap();
                //    Graphics.FromImage(new_img).DrawImage(image, 0,0, ,  GraphicsUnit.Pixel);
                frame.directions.Add(next_dir, image);
                pixel_x += width; // push to the next "row"

            }
            
            // Set the proper delay of the frame
            frame.delay = delays[framei];
            
            // Add the frame to our state
            state.frames.Add(frame);
        }
        
        return state;
        }
        List<ImageInfoBlock> praseMetaData(String metaData)
        {
            List<ImageInfoBlock> nodes = new List<ImageInfoBlock>();
            String[] lines = metaData.Split('\n');
            foreach (String line in lines)
            {
                if (Regex.IsMatch(line, "#.*") || line == "")
                {
                    continue;
                }
                Regex reg = new Regex("(\\s*)([^\\s]+)\\s*=\\s*(.*[^\\s])\\s*");
                MatchCollection matchs = reg.Matches(line);
                if (matchs.Count <= 0)
                    throw new IOException("Malformed DMI");
                String indent = matchs[0].Groups[1].Value;
                String key = matchs[0].Groups[2].Value;
                String value = matchs[0].Groups[3].Value;

                ImageInfoBlock block = new ImageInfoBlock();
                block.indent = (indent.Length != 0);
                block.key = key;
                block.value = value;
                nodes.Add(block);
            }
            return nodes;
        }
        class ImageInfoBlock
        {
            public String key = null;
            public String value = null;
            public Boolean indent = false;
        }
    }
}
