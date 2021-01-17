using System.Collections.Generic;
using System.Linq;

namespace SolidPrinciples.OCP.Correct
{
    public class DrawingService
    {
        public void DrawAllShapes(IEnumerable<Shape> shapes)
        {
            shapes.ToList().ForEach(s=> s.Draw());
        }
    }
}