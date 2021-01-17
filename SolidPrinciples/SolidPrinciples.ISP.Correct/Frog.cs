using System;

namespace SolidPrinciples.ISP.Correct
{
    public class Frog : IJumping
    {
        public void Jump()
        {
            Console.WriteLine("Jumping");
        }
    }
}