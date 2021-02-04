using System;

namespace SolidPrinciples.LSP.Violate
{
    public class Square : Rectangle
    {
        public override void SetHeight(double height)
        {
            if (height <= 0)
                throw new ArgumentOutOfRangeException();
            
            Height = Width= height;
        }

        public override void SetWidth(double width)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException();

            Height = Width= width;
        }
    }
}