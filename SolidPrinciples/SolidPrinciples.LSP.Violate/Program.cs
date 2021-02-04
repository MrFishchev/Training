using System;

namespace SolidPrinciples.LSP.Violate
{
    public static class Program
    {
        private static Square _square = new Square();
        
        static void Main()
        {
            var rect = SetSize(_square, 5, 10);
            DrawArea(rect);
        }

        public static Rectangle SetSize(Rectangle rect, double width, double height)
        {
            rect.SetWidth( width);
            rect.SetHeight(height);
            return rect;
        }

        private static void DrawArea(Shape r)
        {
            Console.WriteLine(r.Area());
        }
    }
}