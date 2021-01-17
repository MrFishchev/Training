using System;
using System.Drawing;

namespace SolidPrinciples.OCP.Correct
{
    public class Square : Shape
    {
        public double Side { get; set; }

        public Point TopLeft { get; set; }
        
        public override void Draw()
        {
            Console.WriteLine(nameof(Square));
        }
    }
}