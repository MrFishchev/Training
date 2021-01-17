using System;
using System.Collections.Generic;

namespace SolidPrinciples.OCP.Violate
{
    public class DrawingService
    {
        public void DrawAllShapes(IEnumerable<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                switch (shape)
                {
                    case Circle circle:
                        circle.Draw();
                        break;
                    case Square square:
                        square.Draw();
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
    }
}