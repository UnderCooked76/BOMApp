namespace BOMApp
{
    public class Textbox
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; }

        public Textbox()
        {
            PositionX = 5;
            PositionY = 5;
            Width = 200;
            Height = 100;
            Text = "sample text";
        }
    }
}
