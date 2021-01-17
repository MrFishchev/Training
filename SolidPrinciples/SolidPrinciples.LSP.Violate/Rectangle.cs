using System;

namespace SolidPrinciples.LSP.Violate
{
    public class Rectangle
    {
        public double Width { get; protected set; }
        public double Height { get; protected set; }

        public virtual void SetWidth(double width)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException();
            
            Width = width;
        }

        public virtual void SetHeight(double height)
        {
            if (height <= 0)
                throw new ArgumentOutOfRangeException();

            Height = height;
        }
    }
}