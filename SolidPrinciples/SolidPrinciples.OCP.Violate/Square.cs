using System;
using System.Drawing;

namespace SolidPrinciples.OCP.Violate
{
    public class Square : Shape
    {
        public double Side { get; set; }

        public Point TopLeft { get; set; }
        
        public void Draw()
        {
            Console.WriteLine(nameof(Square));
        }
    }
}