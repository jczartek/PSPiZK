using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace NotePad
{
    public static class Printing
    {
        private static FlowDocument GetFlowDocument (string[] lines, double pageWidth)
        {
            FlowDocument fd = new FlowDocument()
            {
                Background = Brushes.White,
                Foreground = Brushes.Black,

                FontFamily = new FontFamily("Calibri"),
                FontStyle = new FontStyle(),
                FontWeight = FontWeights.Normal,
                FontSize = 20,

                ColumnGap = 0,
                ColumnWidth = pageWidth
            };

            foreach (var line in lines)
                fd.Blocks.Add(new Paragraph(new Run(line)));

            return fd;
        }

        public static void PrintText(string text)
        {
            string[] lines = text.Split('\n')
                                 .Select(line => line.TrimEnd('\r', ' '))
                                 .ToArray();

            PrintDialog pd = new PrintDialog();

            if (pd.ShowDialog() == true)
            {
                FlowDocument fd = GetFlowDocument(lines, pd.PrintableAreaWidth);
                pd.PrintDocument((fd as IDocumentPaginatorSource).DocumentPaginator, fd.Name);
            }
        }
    }
}
