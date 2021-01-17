using System;
using System.Drawing;

namespace SolidPrinciples.OCP.Violate
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Point Center { get; set; }

        public void Draw()
        {
            Console.WriteLine(nameof(Circle));
        }
    }
}