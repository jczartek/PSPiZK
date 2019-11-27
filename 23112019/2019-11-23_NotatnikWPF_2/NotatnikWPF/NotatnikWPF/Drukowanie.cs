using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

public static class Drukowanie
{
    private static FlowDocument twórzDokument(string[] lines, double pageWidth)
    {
        FlowDocument fd = new FlowDocument();

        //kolory
        fd.Background = Brushes.White;
        fd.Foreground = Brushes.Black;

        //czcionka
        fd.FontFamily = new FontFamily("Calibri");
        fd.FontStyle = new FontStyle();
        fd.FontWeight = FontWeights.Bold;
        fd.FontSize = 20;

        //jedna kolumna
        fd.ColumnGap = 0;
        fd.ColumnWidth = pageWidth;

        foreach(string linia in lines)
        {
            Paragraph p = new Paragraph(new Run(linia));
            fd.Blocks.Add(p);
        }

        return fd;
    }

    public static void PrintText(string[] lines)
    {
        PrintDialog pd = new PrintDialog();

        if(pd.ShowDialog() == true)
        {
            FlowDocument fd = twórzDokument(lines, pd.PrintableAreaWidth);
            pd.PrintDocument((fd as IDocumentPaginatorSource).DocumentPaginator, fd.Name);
        }
    }

    public static void PrintText(string tekst)
    {
        string[] lines = tekst.Split('\n');
        for(int i = 0; i < lines.Length; ++i)
        {
            lines[i] = lines[i].TrimEnd('\r', ' ');
        }
        PrintText(lines);
    }
}

