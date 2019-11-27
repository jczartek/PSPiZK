using System.Windows.Controls;
using System.Windows.Documents;

namespace ImagePrinter
{
    public static class Printing
    {
        private static FlowDocument getFlowDocument(Image image, double widht, double height)
        {
            Image nImage = new Image() { Source = image.Source.Clone() };

            if (nImage.Width > widht) nImage.Width = widht;

            if (nImage.Height > height) nImage.Height = height;

            return new FlowDocument(new BlockUIContainer(nImage));
        }

        public static void PrintImage(Image image)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                FlowDocument flowDocument = getFlowDocument(image, printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
                printDialog.PrintDocument((flowDocument as IDocumentPaginatorSource).DocumentPaginator, flowDocument.Name);
            }
        }
    }
}
