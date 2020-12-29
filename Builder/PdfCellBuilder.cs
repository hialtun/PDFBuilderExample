using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFBuilerExample.Builder
{
    public class PdfCellBuilder
    {
        private PdfPCell PdfPCell { get; set; }
        private Font DefaultFont { get; set; }
        public PdfCellBuilder(){
            PdfPCell = new PdfPCell();
            DefaultFont = new Font(Font.FontFamily.TIMES_ROMAN ,12, Font.NORMAL);
        }
        public PdfCellBuilder(PdfPCell pdfPCell) {
            PdfPCell = pdfPCell;
        }
        public PdfCellBuilder FontSize(int size)
        {
            DefaultFont.Size = size;
            return this;
        }
        public PdfCellBuilder FontStyle(int style)
        {
            DefaultFont.SetStyle(style);
            return this;
        }
        public PdfCellBuilder Phrase(string text)
        {
            PdfPCell.Phrase = new Phrase(text, DefaultFont);
            return this;
        }
        public PdfCellBuilder BackgroundColor(BaseColor cellColor)
        {
            PdfPCell.BackgroundColor = cellColor;
            return this;
        }
        public PdfCellBuilder Colspan(int col)
        {
            PdfPCell.Colspan = col;
            return this;
        }
        public PdfCellBuilder Border(int borderType)
        {
            PdfPCell.Border = borderType;
            return this;
        }
        public PdfCellBuilder HorizontalAlignment(int alignment)
        {
            PdfPCell.HorizontalAlignment = alignment;
            return this;
        }
        public PdfCellBuilder VerticalAlignment(int alignment)
        {
            PdfPCell.VerticalAlignment = alignment;
            return this;
        }
        public PdfCellBuilder Padding(int padding)
        {
            PdfPCell.Padding = padding;
            return this;
        }
        public PdfPCell Build()
        {
            return PdfPCell;
        }
    }
}
