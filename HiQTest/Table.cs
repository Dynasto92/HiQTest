namespace HiQTest
{
    public class Table
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Table(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}
