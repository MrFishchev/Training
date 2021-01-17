using System;

namespace SolidPrinciples.DIP.Correct
{
    public class ConsolePrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Print into the console");
        }
    }
}