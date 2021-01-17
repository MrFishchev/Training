namespace SolidPrinciples.DIP.Violate
{
    public class Document
    {
        private readonly ConsolePrinter _consolePrinter;
        private readonly PdfPrinter _pdfPrinter;

        public Document()
        {
            _consolePrinter = new ConsolePrinter();
            _pdfPrinter = new PdfPrinter();
        }
    }
}