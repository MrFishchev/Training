using System;

namespace SolidPrinciples.LSP.Correct
{
    public class Square : Shape
    {
        public double Side { get; private set; }

        public void SetSide(double side)
        {
            if (side <= 0)
                throw new ArgumentOutOfRangeException();
            
            Side = side;
        }

        public override double Area()
        {
            return Side * Side;
        }
    }
}