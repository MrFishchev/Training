using System;
using System.Drawing;

namespace SolidPrinciples.OCP.Correct
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Point Center { get; set; }
        
        public override void Draw()
        {
            Console.WriteLine(nameof(Circle));
        }
    }
}