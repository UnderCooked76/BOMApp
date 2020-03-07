using System;

namespace BOMApp
{
    public class Ellipse
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int HorizontalDiameter { get; set; }
        public int VerticalDiameter { get; set; }

        public Ellipse()
        {
            PositionX = 100;
            PositionY = 150;
            HorizontalDiameter = 300;
            VerticalDiameter = 200;
        }
    }
}
