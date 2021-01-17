namespace SolidPrinciples.DIP.Correct
{
    public class Document
    {
        private readonly IPrinter _printer;

        public Document(IPrinter printer)
        {
            _printer = printer;
        }
    }
}