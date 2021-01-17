using System;

namespace SolidPrinciples.ISP.Violate
{
    public class Bird : IAnimal
    {
        public void Jump()
        {
            Console.WriteLine("Jumping");
        }

        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }
}