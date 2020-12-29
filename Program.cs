using iTextSharp.text;
using iTextSharp.text.pdf;
using PDFBuilerExample.Builder;
using System;
using System.IO;
using static iTextSharp.text.Font;

namespace PDFBuilerExample
{
    class Program
    {
        static void Main(string[] args)
        {

            Document doc = new Document(new Rectangle(595, 842), 0, 0, 5, 5);
            string filePath = @"C:\temp\";
            filePath += "builder.pdf";
            var fileStream = new FileStream(filePath, FileMode.Create);
            doc.SetPageSize(PageSize.A4.Rotate());
            var writer = PdfWriter.GetInstance(doc, fileStream);
            doc.Open();

            string dummyText1 = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book.";
            string dummyText2 = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."; 
            
            // with pattern
            PdfPTable pdfTable1 = new PdfPTable(3);
            pdfTable1.AddCell(
                    new PdfCellBuilder().Colspan(2).FontSize(14).FontStyle(BOLD).Border(Rectangle.NO_BORDER)
                        .HorizontalAlignment(Element.ALIGN_CENTER).Phrase("Kolon 1").BackgroundColor(BaseColor.LIGHT_GRAY).Build()
                );
            pdfTable1.AddCell(
                    new PdfCellBuilder().Colspan(1).FontSize(14).FontStyle(BOLD).Border(Rectangle.NO_BORDER)
                        .HorizontalAlignment(Element.ALIGN_CENTER).Phrase("Kolon 2").BackgroundColor(BaseColor.LIGHT_GRAY).Build()
                );
            pdfTable1.AddCell(
                    new PdfCellBuilder().Colspan(2).FontSize(11).Phrase(dummyText1).Build()
                );
            pdfTable1.AddCell(
                    new PdfCellBuilder().Colspan(1).FontSize(11).Phrase(dummyText2).Build()
                );
            doc.Add(pdfTable1);

            doc.Add(new Phrase(" "));

            // without pattern
            PdfPTable pdfTable2 = new PdfPTable(3);
            Font Font14Bold = new Font(FontFamily.TIMES_ROMAN, 14, BOLD);
            PdfPCell PdfPCell = new PdfPCell()
            {
                Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.GRAY, Border = Rectangle.NO_BORDER,
                Phrase = new Phrase("Kolon 1", Font14Bold)
            };
            pdfTable2.AddCell(PdfPCell);
            PdfPCell = new PdfPCell()
            {
                Colspan = 1, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = BaseColor.GRAY, Border = Rectangle.NO_BORDER,
                Phrase = new Phrase("Kolon 2", Font14Bold)
            };
            pdfTable2.AddCell(PdfPCell);
            Font Font11Normal = new Font(FontFamily.TIMES_ROMAN, 11, NORMAL);
            PdfPCell = new PdfPCell()
            {
                Colspan = 2, Phrase = new Phrase(dummyText1, Font11Normal)
            };
            pdfTable2.AddCell(PdfPCell);
            PdfPCell = new PdfPCell()
            {
                Colspan = 1, Phrase = new Phrase(dummyText2, Font11Normal)
            };
            pdfTable2.AddCell(PdfPCell);
            doc.Add(pdfTable2);

            doc.Close();
            fileStream.Close();
        }
    }
}
