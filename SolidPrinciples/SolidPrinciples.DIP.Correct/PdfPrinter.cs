using System;

namespace SolidPrinciples.DIP.Correct
{
    public class PdfPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Print into a PDF file");
        }
    }
}