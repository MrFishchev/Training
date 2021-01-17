using System;

namespace SolidPrinciples.ISP.Correct
{
    public class Bird : IJumping, IFlying
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