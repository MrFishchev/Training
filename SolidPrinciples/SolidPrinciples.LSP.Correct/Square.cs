using System;

namespace SolidPrinciples.LSP.Correct
{
    public class Square
    {
        public double Side { get; private set; }

        public void SetSide(double side)
        {
            if (side <= 0)
                throw new ArgumentOutOfRangeException();
            
            Side = side;
        }
    }
}