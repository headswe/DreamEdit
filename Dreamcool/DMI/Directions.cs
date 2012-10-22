using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamEdit.DMI
{
public  class Directions {
	public static int CENTER = 0;
	public static int NORTH  = 1;
	public static int SOUTH  = 2;
	public static int EAST   = 4;
	public static int WEST   = 8;
	public static int UP     = 16;
	public static int DOWN   = 32;
	
	public static int NORTHEAST = 5;
	public static int NORTHWEST = 9;
	public static int SOUTHEAST = 6;
	public static int SOUTHWEST = 10;
    public static int[] ALL = new int[] { NORTH, NORTHEAST, NORTHWEST, SOUTH, SOUTHEAST, SOUTHWEST, EAST, WEST, };
    public static string dirToString(int k)
    {
        switch (k)
        {
            case 0:
                return "Center";
            case 1:
                return "North";
            case 2:
                return "South";
            case 4:
                return "East";
            case 8:
                return "West";
            case 16:
                return "Up";
            case 5:
                return "Northeast";
            case 9:
                return "Northwest";
            case 6:
                return "Southeast";
            case 10:
                return "Southwest";
        }
        return null;
    }
}
	
}
