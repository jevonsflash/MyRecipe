using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;

namespace MyRecipe.Helper
{
    public class ColorGenerator
    {

        public static Color GetRandomLightColor()
        {
            Random r = new Random();
            List<Color> colors = new List<Color>() {
                Colors.PapayaWhip,
                Colors.LemonChiffon,
                Colors.LightPink,
                Colors.LightYellow,
                Colors.Moccasin,
                Colors.LightGoldenrodYellow,
                Colors.LightGreen,
                Colors.LightSalmon
            };
            return colors[r.Next(colors.Count)];
        }
        public static Color GetColorGroup1()
        {

            Random r = new Random();
            List<Color> colors = new List<Color>() {
                new Color() { R= 255,G=191,B=44,A=255},
                new Color() { R= 232,G=147,B=40,A=255},
                new Color() { R= 255,G=137,B=57,A=255},
                new Color() { R= 232,G=74,B=40,A=255},
                //new Color() { R= 255,G=47,B=54,A=255},
            };
            return colors[r.Next(colors.Count)];

        }
    }
}
