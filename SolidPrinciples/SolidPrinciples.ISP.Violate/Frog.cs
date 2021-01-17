using System;

namespace SolidPrinciples.ISP.Violate
{
    public class Frog : IAnimal
    {
        public void Jump()
        {
            Console.WriteLine("Jumping");
        }

        public void Fly()
        {
            throw new NotSupportedException($"Flying is not supported");
        }
    }
}